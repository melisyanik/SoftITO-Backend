using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public string? Image { get; set; }


        public int Quota { get; set; }


        public int EnrolledCount { get; set; } = 0;

        public int CategoryId { get; set; }
        public int InstructorId { get; set; }

        public Category Category { get; set; }
        public Instructor Instructor { get; set; }

        public ICollection<Enrollment>? Enrollments { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
