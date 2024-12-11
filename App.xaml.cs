using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using BeiDanCi.Data;
using System.IO;

namespace BeiDanCi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WordDbContext _dbContext;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "words.db");
            var options = new DbContextOptionsBuilder<WordDbContext>()
                .UseSqlite($"Data Source={dbPath}")
                .Options;

            _dbContext = new WordDbContext(options);
            _dbContext.Database.EnsureCreated();

            MainWindow = new MainWindow(_dbContext);
            MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _dbContext?.Dispose();
            base.OnExit(e);
        }
    }
}
