using System.Windows.Media;

namespace BeiDanCi.Models
{
    public class Settings
    {
        public int WordsPerPage { get; set; } = 5;
        public double FontSize { get; set; } = 16;
        public string BackgroundColor { get; set; } = "#F5F5F7";
        public bool RandomizeWords { get; set; } = true;
    }
}
