using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BeiDanCi.Models;
using System.Linq;
using System.Windows;
using BeiDanCi.Data;
using Microsoft.EntityFrameworkCore;

namespace BeiDanCi.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly WordDbContext _dbContext;
        private readonly SettingsViewModel _settingsViewModel;
        private ObservableCollection<Word> _currentWords;
        private int _currentPage;
        private double _progress;
        private int _totalWords;

        public ObservableCollection<Word> CurrentWords
        {
            get => _currentWords;
            set => SetProperty(ref _currentWords, value);
        }

        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);
        }

        public ICommand NextPageCommand { get; }
        public ICommand ShowTranslationCommand { get; }
        public ICommand OpenSettingsCommand { get; }

        public MainViewModel(WordDbContext dbContext)
        {
            _dbContext = dbContext;
            _settingsViewModel = new SettingsViewModel();
            CurrentWords = new ObservableCollection<Word>();
            
            NextPageCommand = new RelayCommand(ExecuteNextPage);
            ShowTranslationCommand = new RelayCommand<Word>(ShowTranslation);
            OpenSettingsCommand = new RelayCommand(OpenSettings);
            
            LoadWords();
            UpdateProgress();
        }

        private async void LoadWords()
        {
            var skip = _currentPage * _settingsViewModel.WordsPerPage;
            var words = await _dbContext.Words
                .Skip(skip)
                .Take(_settingsViewModel.WordsPerPage)
                .ToListAsync();

            if (_settingsViewModel.RandomizeWords)
            {
                words = words.OrderBy(x => Guid.NewGuid()).ToList();
            }

            CurrentWords.Clear();
            foreach (var word in words)
            {
                CurrentWords.Add(word);
            }

            _totalWords = await _dbContext.Words.CountAsync();
        }

        private void ExecuteNextPage()
        {
            _currentPage++;
            LoadWords();
        }

        private async void ShowTranslation(Word word)
        {
            if (word != null)
            {
                MessageBox.Show(word.Chinese, word.English, MessageBoxButton.OK, MessageBoxImage.Information);
                word.IsLearned = true;
                word.LastReviewDate = DateTime.Now;
                word.ReviewCount++;
                
                await _dbContext.SaveChangesAsync();
                UpdateProgress();
            }
        }

        private async void UpdateProgress()
        {
            var learnedCount = await _dbContext.Words.CountAsync(w => w.IsLearned);
            Progress = (double)learnedCount / _totalWords * 100;
        }

        private void OpenSettings()
        {
            var settingsWindow = new Views.SettingsWindow(_settingsViewModel);
            if (settingsWindow.ShowDialog() == true)
            {
                // Reload words with new settings
                _currentPage = 0;
                LoadWords();
            }
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke() ?? true;

        public void Execute(object parameter) => _execute();
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<T> _canExecute;

        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => _execute((T)parameter);
    }
}
