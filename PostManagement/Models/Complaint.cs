using System.ComponentModel.DataAnnotations;

namespace SocialManagement.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }

        public string Reason { get; set; } 

        public string ReporterName { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsResolved { get; set; } = false;
    }
}
