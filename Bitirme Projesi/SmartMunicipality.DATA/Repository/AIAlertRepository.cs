using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class AIAlertRepository : EFRepository<AIAlert>, IAIAlertRepository
    {
        private readonly ApplicationDbContext _context;
        public AIAlertRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
