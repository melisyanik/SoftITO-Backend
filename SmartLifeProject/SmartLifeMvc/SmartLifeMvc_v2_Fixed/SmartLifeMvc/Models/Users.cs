using Microsoft.AspNetCore.Identity;

namespace SmartLifeMvc.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
    }
}