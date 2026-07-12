using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnouncementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            var announcements = await _context.Announcements
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.PublishDate)
                .ToListAsync();

            return Ok(announcements);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncement(int id)
        {
            var ann = await _context.Announcements.FindAsync(id);
            if (ann == null) return NotFound();
            return Ok(ann);
        }

        
        [HttpPost]
        public async Task<IActionResult> PostAnnouncement([FromBody] Announcement announcement)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            announcement.PublishDate = DateTime.Now;
            announcement.IsActive = true;

            _context.Announcements.Add(announcement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAnnouncement), new { id = announcement.Id }, announcement);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnouncement(int id, [FromBody] Announcement announcement)
        {
            var existing = await _context.Announcements.FindAsync(id);
            if (existing == null) return NotFound();

            existing.Title = announcement.Title;
            existing.Content = announcement.Content;
            existing.IsActive = announcement.IsActive;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var ann = await _context.Announcements.FindAsync(id);
            if (ann == null) return NotFound();

            _context.Announcements.Remove(ann);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
