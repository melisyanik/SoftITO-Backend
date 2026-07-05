using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduMaster.Data.IRepository;

namespace EduMaster.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Course { get; }
        ICategoryRepository Category { get; }
        IInstructorRepository Instructor { get; }
        IEnrollmentRepository Enrollment { get; }
        ICommentRepository Comment { get; }

        void Save();
    }
}