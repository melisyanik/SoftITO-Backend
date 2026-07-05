using EduMaster.Data.IRepository;
using EduMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Data.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> Search(string keyword)
        {
            return _context.Courses
                .Where(x => x.Title.Contains(keyword))
                .ToList();
        }
    }
}