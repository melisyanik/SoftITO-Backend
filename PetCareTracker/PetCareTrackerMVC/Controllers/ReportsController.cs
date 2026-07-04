using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTrackerMVC.Models;
using PetCareTrackerMVC.Repositories;
using System.Security.Claims;

namespace PetCareTrackerMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly BaseRepository _repo;
        public ReportsController(BaseRepository repo) { _repo = repo; }

        public async Task<IActionResult> Index()
        {
            var upcomingVacs = await _repo.Query<dynamic>("sp_Report_UpcomingVaccinations");
            var upcomingApps = await _repo.Query<dynamic>("sp_Report_UpcomingAppointments");
            
            ViewBag.Vacs = upcomingVacs;
            ViewBag.Apps = upcomingApps;
            return View();
        }
    }
}
