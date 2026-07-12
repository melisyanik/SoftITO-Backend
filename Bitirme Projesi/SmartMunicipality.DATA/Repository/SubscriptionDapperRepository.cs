using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class SubscriptionDapperRepository : DapperRepository<Subscription>, ISubscriptionDapperRepository
    {
        public SubscriptionDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
