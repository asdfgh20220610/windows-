using System;
using System.ComponentModel.DataAnnotations;

namespace BeiDanCi.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string English { get; set; }
        
        [Required]
        public string Chinese { get; set; }
        
        public bool IsLearned { get; set; }
        
        public DateTime LastReviewDate { get; set; }
        
        public int ReviewCount { get; set; }
    }
}
