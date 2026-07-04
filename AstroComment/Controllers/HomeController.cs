using AstroComment.Data;
using AstroComment.Models;
using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var burclar =
                Context.Query<ZodiacModel>("sp_GetAllZodiacs");

            return View(burclar);
        }
    }
}
