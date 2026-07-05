using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Models
{
    public class Instructor
    {
            public int Id { get; set; }
            public string FullName { get; set; }
            public string Expertise { get; set; }
            public string? Image { get; set; }

            public ICollection<Course>? Courses { get; set; }
        
    }
}
