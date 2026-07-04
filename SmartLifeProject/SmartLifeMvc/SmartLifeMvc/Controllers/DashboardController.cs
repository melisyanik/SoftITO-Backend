using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLifeMvc.Models;
using System.Security.Claims;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var goals = _context.Goals
                .Where(x => x.UserId == userId)
                .ToList();

            ViewBag.Goals = goals;

            return View();
        }
    }
}
