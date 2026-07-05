using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Models
{
    public class Comment
    {
            public int Id { get; set; }

            public int CourseId { get; set; }
            public string UserId { get; set; }

            public string Text { get; set; }
            public DateTime CommentDate { get; set; }

            public Course Course { get; set; }
            public User User { get; set; }
    }
}
