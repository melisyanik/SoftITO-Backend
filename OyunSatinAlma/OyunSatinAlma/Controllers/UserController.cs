using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyunSatinAlma.DATA.Data;
using OyunSatinAlma.MODEL;

namespace OyunSatinAlma.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext db;

        public UserController(ApplicationDBContext context)
        {
            db = context;
        }

       
        public IActionResult Index()
        {
            var oyunlar = db.Oyunlar.ToList();
            return View(oyunlar);
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Create(int oyunId)
        {
            var oyunlar = db.Oyunlar.ToList();
            ViewBag.Oyunlar = oyunlar;
            ViewBag.SelectedOyunId = oyunId;
            return View();
        }

        [HttpPost]
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Create(int oyunId, string dummyParam)
        {
            var oyun = db.Oyunlar.FirstOrDefault(x => x.OyunId == oyunId);
            if (oyun == null)
            {
                ModelState.AddModelError("", "Geçersiz oyun seçildi!");
                ViewBag.Oyunlar = db.Oyunlar.ToList();
                return View();
            }

            var userEmail = User.Identity.Name;
            var musteri = db.Musteriler.FirstOrDefault(m => m.Email == userEmail);

            if (musteri == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var siparis = new Siparis
            {
                OyunId = oyun.OyunId, 
                MusteriId = musteri.MusteriId,
                SiparisTarihi = DateTime.Now,
                Durum = "Beklemede"
            };

            db.Siparisler.Add(siparis);
            db.SaveChanges();

            return RedirectToAction("Siparislerim");
        }

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Siparislerim()
        {
            var userEmail = User.Identity.Name;
            var musteri = db.Musteriler.FirstOrDefault(m => m.Email == userEmail);

            if (musteri == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var siparisler = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .Where(x => x.MusteriId == musteri.MusteriId)
                .OrderByDescending(x => x.SiparisId)
                .ToList();

            return View(siparisler);
        }
        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Oyunlarim(string searchType, string arama)
        {
            var userEmail = User.Identity.Name;
            if (string.IsNullOrEmpty(userEmail)) return RedirectToAction("Login", "Auth");

            var musteri = db.Musteriler.FirstOrDefault(m => m.Email == userEmail);
            if (musteri == null)
            {
                return View(new List<OyunSatinAlma.MODEL.Siparis>());
            }

            var query = db.Siparisler
                .Include(x => x.Oyun)
                .Where(x => x.MusteriId == musteri.MusteriId)
                .AsQueryable();

            if (!string.IsNullOrEmpty(arama))
            {
                if (searchType == "tur")
                {
                    query = query.Where(x => x.Oyun.Tur.Contains(arama));
                }
                else
                {
                    query = query.Where(x => x.Oyun.OyunAdi.Contains(arama));
                }
            }

            ViewBag.SearchType = searchType ?? "oyunAdi";
            ViewBag.Arama = arama;

            var resultList = query.ToList()
                                  .GroupBy(x => x.OyunId)
                                  .Select(g => g.OrderByDescending(x => x.SiparisTarihi).First())
                                  .ToList();

            return View(resultList);
        }
    }
}