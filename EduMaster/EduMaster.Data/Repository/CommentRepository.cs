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
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsByCourse(int courseId)
        {
            return _context.Comments
                .Include(x => x.User)
                .Where(x => x.CourseId == courseId)
                .ToList();
        }
    }
}