using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ServiceTypeRepository : EFRepository<ServiceType>, IServiceTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public ServiceTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
