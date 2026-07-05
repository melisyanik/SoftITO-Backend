using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduMaster.Data.IRepository;

namespace EduMaster.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICourseRepository Course => new CourseRepository(_context);
        public ICategoryRepository Category => new CategoryRepository(_context);
        public IInstructorRepository Instructor => new InstructorRepository(_context);
        public IEnrollmentRepository Enrollment => new EnrollmentRepository(_context);
        public ICommentRepository Comment => new CommentRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
