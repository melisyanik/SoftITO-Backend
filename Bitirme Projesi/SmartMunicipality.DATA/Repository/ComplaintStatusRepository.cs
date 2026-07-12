using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintStatusRepository : EFRepository<ComplaintStatus>, IComplaintStatusRepository
    {
        private readonly ApplicationDbContext _context;
        public ComplaintStatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
