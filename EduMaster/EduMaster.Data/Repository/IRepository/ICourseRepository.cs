using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduMaster.Models;

namespace EduMaster.Data.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> Search(string keyword);
    }
}