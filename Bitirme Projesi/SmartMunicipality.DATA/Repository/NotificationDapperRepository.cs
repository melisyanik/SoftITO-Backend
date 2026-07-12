using Microsoft.Extensions.Configuration;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class NotificationDapperRepository : DapperRepository<Notification>, INotificationDapperRepository
    {
        public NotificationDapperRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
