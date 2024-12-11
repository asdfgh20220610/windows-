using System.IO;
using System.Text.Json;
using BeiDanCi.Models;

namespace BeiDanCi.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private Settings _settings;
        private readonly string _settingsPath = "settings.json";

        public int WordsPerPage
        {
            get => _settings.WordsPerPage;
            set
            {
                _settings.WordsPerPage = value;
                OnPropertyChanged();
            }
        }

        public double FontSize
        {
            get => _settings.FontSize;
            set
            {
                _settings.FontSize = value;
                OnPropertyChanged();
            }
        }

        public string BackgroundColor
        {
            get => _settings.BackgroundColor;
            set
            {
                _settings.BackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public bool RandomizeWords
        {
            get => _settings.RandomizeWords;
            set
            {
                _settings.RandomizeWords = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel()
        {
            LoadSettings();
        }

        public void LoadSettings()
        {
            if (File.Exists(_settingsPath))
            {
                string json = File.ReadAllText(_settingsPath);
                _settings = JsonSerializer.Deserialize<Settings>(json) ?? new Settings();
            }
            else
            {
                _settings = new Settings();
            }
        }

        public void SaveSettings()
        {
            string json = JsonSerializer.Serialize(_settings);
            File.WriteAllText(_settingsPath, json);
        }
    }
}
