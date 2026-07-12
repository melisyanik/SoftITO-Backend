using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ConsumptionRecordRepository : EFRepository<ConsumptionRecord>, IConsumptionRecordRepository
    {
        private readonly ApplicationDbContext _context;
        public ConsumptionRecordRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
