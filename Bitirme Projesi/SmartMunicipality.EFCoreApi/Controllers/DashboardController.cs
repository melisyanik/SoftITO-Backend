using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var announcements = await _context.Announcements
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.PublishDate)
                .Take(5)
                .Select(a => new { a.Id, a.Title, a.Content, a.PublishDate })
                .ToListAsync();

            var news = await _context.Announcements
                .Where(a => a.IsActive)
                .OrderByDescending(a => a.PublishDate)
                .Take(3)
                .Select(a => new { a.Id, a.Title, a.Content, a.PublishDate })
                .ToListAsync();

            var complaints = await _context.Complaints
                .Include(c => c.Status)
                .Select(c => new { c.Id, c.Title, c.Address, StatusName = c.Status != null ? c.Status.Name : "", c.Latitude, c.Longitude })
                .ToListAsync();

            var totalCitizens = await _context.Users.CountAsync();
            var resolved = complaints.Count(c => c.StatusName == "Çözüldü" || c.StatusName == "Çözüldü"); 
            var pending = complaints.Count(c => c.StatusName != "Çözüldü");

            var heatMapData = complaints.Select(c => {
                double lat = c.Latitude;
                double lng = c.Longitude;

                if (lat == 0 || lng == 0)
                {
                    lat = 41.0082;
                    lng = 28.9784;

                    switch (c.Address) {
                        case "Kadıköy": lat = 40.9819; lng = 29.0270; break;
                        case "Beşiktaş": lat = 41.0422; lng = 29.0083; break;
                        case "Üsküdar": lat = 41.0256; lng = 29.0170; break;
                        case "Şişli": lat = 41.0610; lng = 28.9878; break;
                        case "Fatih": lat = 41.0165; lng = 28.9482; break;
                        case "Maltepe": lat = 40.9255; lng = 29.1384; break;
                        case "Ataşehir": lat = 40.9856; lng = 29.1080; break;
                        case "Sarıyer": lat = 41.1685; lng = 29.0532; break;
                    }

                    lat = lat + ((c.Id % 10) - 5) * 0.005;
                    lng = lng + ((c.Id % 10) - 5) * 0.005;
                }

                return new
                {
                    Latitude = lat,
                    Longitude = lng,
                    Intensity = 0.5 + (c.Id % 5) * 0.1,
                    Title = c.Title ?? "Şikayet",
                    StatusName = c.StatusName ?? "Bekliyor",
                    Address = c.Address ?? ""
                };
            }).ToList();

            return Ok(new
            {
                TotalCitizens = totalCitizens,
                ResolvedComplaints = resolved,
                PendingComplaints = pending,
                Announcements = announcements,
                LatestNews = news,
                HeatMapPoints = heatMapData
            });
        }
    }
}
