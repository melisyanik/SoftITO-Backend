using EduMaster.Data.IRepository;
using EduMaster.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduMaster.Data.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetEnrollmentsByUser(string userId)
        {
            return _context.Enrollments
                .Include(x => x.Course)
                .Where(x => x.UserId == userId)
                .ToList();
        }

        public IEnumerable<Enrollment> GetEnrollmentsByCourse(int courseId)
        {
            return _context.Enrollments
                .Include(x => x.User)
                .Where(x => x.CourseId == courseId)
                .ToList();
        }
    }
}