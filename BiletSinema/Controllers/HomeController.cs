using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;
using QRCoder;

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

            string hedefWebsitesi = "https://imdb.com";
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                using (QRCodeData rCodeData = qrGenerator.CreateQrCode(hedefWebsitesi, QRCodeGenerator.ECCLevel.Q))
                {
                    using (PngByteQRCode qrCode = new PngByteQRCode(rCodeData))
                    {
                        byte[] qrCodeBytes = qrCode.GetGraphic(20);
                        string base64Gorsel = Convert.ToBase64String(qrCodeBytes);
                        ViewBag.KareKodGorseli = $"data:image/png;base64,{base64Gorsel}";
                    }
                }
            }

            return View(model);
        }
    }
}