using Microsoft.AspNetCore.Identity;

namespace EduMaster.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Image { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}