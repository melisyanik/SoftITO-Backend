using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintCategoryRepository : EFRepository<ComplaintCategory>, IComplaintCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public ComplaintCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
