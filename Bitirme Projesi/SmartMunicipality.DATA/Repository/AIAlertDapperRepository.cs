using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class AIAlertDapperRepository : DapperRepository<AIAlert>, IAIAlertDapperRepository
    {
        public AIAlertDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
