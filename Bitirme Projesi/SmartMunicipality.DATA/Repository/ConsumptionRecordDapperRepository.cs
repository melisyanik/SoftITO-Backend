using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ConsumptionRecordDapperRepository : DapperRepository<ConsumptionRecord>, IConsumptionRecordDapperRepository
    {
        public ConsumptionRecordDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
