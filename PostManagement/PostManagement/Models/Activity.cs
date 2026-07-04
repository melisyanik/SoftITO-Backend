using System.ComponentModel.DataAnnotations;

namespace SocialManagement.Models
{
    public class ActivityLog
    {
        [Key]
        public int Id { get; set; }

        public string Action { get; set; } 

        public string Detail { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}