using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTrackerMVC.Repositories;

namespace PetCareTrackerMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly BaseRepository _repo;
        public DashboardController(BaseRepository repo) { _repo = repo; }

        public async Task<IActionResult> Index()
        {
            var stats = await _repo.QueryFirstOrDefault<dynamic>("sp_Dashboard_Get");
            return View(stats);
        }
    }
}
