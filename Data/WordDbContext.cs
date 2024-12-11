using Microsoft.EntityFrameworkCore;
using BeiDanCi.Models;

namespace BeiDanCi.Data
{
    public class WordDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }

        public WordDbContext(DbContextOptions<WordDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().HasData(
                new Word { Id = 1, English = "Hello", Chinese = "你好", IsLearned = false, LastReviewDate = System.DateTime.Now },
                new Word { Id = 2, English = "World", Chinese = "世界", IsLearned = false, LastReviewDate = System.DateTime.Now },
                new Word { Id = 3, English = "Computer", Chinese = "电脑", IsLearned = false, LastReviewDate = System.DateTime.Now },
                new Word { Id = 4, English = "Language", Chinese = "语言", IsLearned = false, LastReviewDate = System.DateTime.Now },
                new Word { Id = 5, English = "Study", Chinese = "学习", IsLearned = false, LastReviewDate = System.DateTime.Now }
            );
        }
    }
}
