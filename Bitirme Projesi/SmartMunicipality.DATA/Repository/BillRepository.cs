using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class BillRepository : EFRepository<Bill>, IBillRepository
    {
        private readonly ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
