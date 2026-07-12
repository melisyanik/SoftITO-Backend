using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintRepository : EFRepository<Complaint>, IComplaintRepository
    {
        private readonly ApplicationDbContext _context;
        public ComplaintRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
