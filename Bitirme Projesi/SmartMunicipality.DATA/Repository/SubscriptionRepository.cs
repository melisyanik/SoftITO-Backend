using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class SubscriptionRepository : EFRepository<Subscription>, ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;
        public SubscriptionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
