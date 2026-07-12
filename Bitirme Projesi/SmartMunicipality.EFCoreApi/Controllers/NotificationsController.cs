using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NotificationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetNotificationsByUser(string userId)
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.CreatedDate)
                .ToListAsync();

            return Ok(notifications);
        }

        [HttpGet("User/{userId}/Unread")]
        public async Task<IActionResult> GetUnreadNotifications(string userId)
        {
            var notifications = await _context.Notifications
                .Where(n => n.UserId == userId && !n.IsRead)
                .OrderByDescending(n => n.CreatedDate)
                .Select(n => new { n.Id, n.Title, n.Message, n.CreatedDate })
                .ToListAsync();

            return Ok(notifications);
        }

        [HttpPut("{id}/Read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return NotFound();

            notification.IsRead = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] SmartMunicipality.MODEL.Notification notification)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            notification.CreatedDate = System.DateTime.Now;
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Bildirim başarıyla oluşturuldu." });
        }
    }
}
