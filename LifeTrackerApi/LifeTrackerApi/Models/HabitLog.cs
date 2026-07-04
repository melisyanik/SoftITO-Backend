using System.ComponentModel.DataAnnotations;

namespace LifeTrackerApi.Models
{
    public class HabitLog
    {
        [Key]
        public int Id { get; set; }

        public string HabitName { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}