using System.ComponentModel.DataAnnotations;

namespace LifeTrackerApi.Models
{
    public class ExpenseLog
    {
        [Key]
        public int Id { get; set; }

        public string Category { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}