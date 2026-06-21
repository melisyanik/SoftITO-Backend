using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;

namespace BiletSinema.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Filmler = dbContext.Filmler
                    .Include(x => x.kategori)
                    .ToList(),

                Diziler = dbContext.Diziler
                    .Include(x => x.kategori)
                    .ToList(),

                Tiyatrolar = dbContext.Tiyatrolar
                    .Include(x => x.kategori)
                    .ToList()
            };

            return View(model);
        }
    }
}