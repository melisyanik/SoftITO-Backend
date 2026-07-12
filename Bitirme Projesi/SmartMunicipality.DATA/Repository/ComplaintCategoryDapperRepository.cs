using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class ComplaintCategoryDapperRepository : DapperRepository<ComplaintCategory>, IComplaintCategoryDapperRepository
    {
        public ComplaintCategoryDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
