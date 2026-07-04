using System.ComponentModel.DataAnnotations;

namespace LifeTrackerApi.Models
{
    public class MoodLog
    {
        [Key]
        public int Id { get; set; }

        public string Mood { get; set; } 

        public string? Note { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}