using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintStatusDapperRepository : DapperRepository<ComplaintStatus>, IComplaintStatusDapperRepository
    {
        public ComplaintStatusDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
