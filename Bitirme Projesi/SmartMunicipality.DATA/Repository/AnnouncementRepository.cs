using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.DATA.Repository
{
    public class AnnouncementRepository : EFRepository<Announcement>, IAnnouncementRepository
    {
        private readonly ApplicationDbContext _context;
        public AnnouncementRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
