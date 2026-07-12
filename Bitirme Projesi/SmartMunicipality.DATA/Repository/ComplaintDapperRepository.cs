using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintDapperRepository : DapperRepository<Complaint>, IComplaintDapperRepository
    {
        public ComplaintDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
