using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintResponseDapperRepository : DapperRepository<ComplaintResponse>, IComplaintResponseDapperRepository
    {
        public ComplaintResponseDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
