using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ServiceTypeDapperRepository : DapperRepository<ServiceType>, IServiceTypeDapperRepository
    {
        public ServiceTypeDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
