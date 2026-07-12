using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class AnnouncementDapperRepository : DapperRepository<Announcement>, IAnnouncementDapperRepository
    {
        public AnnouncementDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
