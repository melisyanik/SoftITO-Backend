using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SmartMunicipality.MODEL
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string? TcNo { get; set; }

        public string? Address { get; set; }

        public string? District { get; set; }
    }
}