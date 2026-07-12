using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class BillDapperRepository : DapperRepository<Bill>, IBillDapperRepository
    {
        public BillDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
