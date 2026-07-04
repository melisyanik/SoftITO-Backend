using System.ComponentModel.DataAnnotations;

namespace LifeTrackerApi.Models
{
    public class SleepLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime SleepTime { get; set; }

        public DateTime WakeUpTime { get; set; }

        public int Hours { get; set; }
    }
}