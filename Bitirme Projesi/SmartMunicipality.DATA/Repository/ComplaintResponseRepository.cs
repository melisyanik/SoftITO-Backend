using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintResponseRepository : EFRepository<ComplaintResponse>, IComplaintResponseRepository
    {
        private readonly ApplicationDbContext _context;
        public ComplaintResponseRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
