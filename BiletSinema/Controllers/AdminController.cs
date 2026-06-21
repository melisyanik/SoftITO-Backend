using Microsoft.AspNetCore.Mvc;

namespace BiletSinema.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Raporlar");
        }
    }
}
