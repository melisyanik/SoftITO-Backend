using Microsoft.AspNetCore.Authorization;
using BiletSinema.Models;
using BiletSinema.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BiletSinema.Controllers
{
    [Authorize]
    public class RaporController : Controller
    {
        private readonly ApplicationDbContext db;

        public RaporController(ApplicationDbContext context)
        {
            db = context;
        }

        public IActionResult Index(int? raporId)
        {
            var model = new RaporViewModel();

            model.RaporListesi = RaporDropdownHazirla();
            model.SecilenRapor = raporId ?? 1;

        
            ViewBag.KategoriAdlari = db.Kategori.Select(x => x.KategoriAdi).ToList();

            ViewBag.KategoriFilmSayilari = db.Kategori
                .Select(k => db.Filmler.Count(f => f.KategoriNo == k.KategoriNo))
                .ToList();

           
            ViewBag.OzetDagilim = new[]
            {
        db.Filmler.Count(),
        db.Diziler.Count(),
        db.Tiyatrolar.Count()
    };

            switch (model.SecilenRapor)
            {
                case 1:
                    model.FilmRaporu = FilmKategoriLeftJoin();
                    break;

                case 2:
                    model.KategoriRaporu = KategoriFilmRightJoin();
                    break;

                case 3:
                    model.FilmRaporu = FilmKategoriInnerJoin();
                    break;

                case 4:
                    model.GroupRaporu = KategoriFilmGroupBy();
                    break;
            }

            return View(model);
        }

        public List<SelectListItem> RaporDropdownHazirla()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "Film - Kategori", Value = "1" },
                new SelectListItem { Text = "Kategori - Film", Value = "2" },
                new SelectListItem { Text = "Filmler", Value = "3" },
                new SelectListItem { Text = "Kategori Analiz", Value = "4" }
            };
        }

   
        public List<FilmRaporVM> FilmKategoriLeftJoin()
        {
            return (from f in db.Filmler
                    join k in db.Kategori
                    on f.KategoriNo equals k.KategoriNo into fk
                    from k in fk.DefaultIfEmpty()
                    select new FilmRaporVM
                    {
                        FilmAdi = f.Adi,
                        KategoriAdi = k != null ? k.KategoriAdi : "Yok",
                        Puan = f.Puan
                    }).ToList();
        }

   
        public List<KategoriRaporVM> KategoriFilmRightJoin()
        {
            return (from k in db.Kategori
                    join f in db.Filmler
                    on k.KategoriNo equals f.KategoriNo into kf
                    from f in kf.DefaultIfEmpty()
                    select new KategoriRaporVM
                    {
                        KategoriAdi = k.KategoriAdi,
                        FilmAdi = f != null ? f.Adi : "Film Yok"
                    }).ToList();
        }

  
        public List<FilmRaporVM> FilmKategoriInnerJoin()
        {
            return (from f in db.Filmler
                    join k in db.Kategori
                    on f.KategoriNo equals k.KategoriNo
                    select new FilmRaporVM
                    {
                        FilmAdi = f.Adi,
                        KategoriAdi = k.KategoriAdi,
                        Puan = f.Puan
                    }).ToList();
        }

   
        public List<RaporGroupVM> KategoriFilmGroupBy()
        {
            return (from f in db.Filmler
                    join k in db.Kategori
                    on f.KategoriNo equals k.KategoriNo
                    group f by k.KategoriAdi into g
                    select new RaporGroupVM
                    {
                        KategoriAdi = g.Key,
                        FilmSayisi = g.Count(),
                        OrtalamaPuan = g.Average(x => x.Puan)
                    }).ToList();
        }

  
        public IActionResult Dashboard()
        {
            var model = new RaporViewModel
            {
                GenelRapor = GenelDashboard()
            };

            return View(model);
        }


        public GenelRaporVM GenelDashboard()
        {
            return new GenelRaporVM
            {
                ToplamFilm = db.Filmler.Count(),
                ToplamDizi = db.Diziler.Count(),
                ToplamTiyatro = db.Tiyatrolar.Count(),

                OrtalamaFilmPuan = db.Filmler.Any() ? db.Filmler.Average(x => x.Puan) : 0,
                OrtalamaDiziPuan = db.Diziler.Any() ? db.Diziler.Average(x => x.Puan) : 0,
                OrtalamaTiyatroPuan = db.Tiyatrolar.Any() ? db.Tiyatrolar.Average(x => x.Puan) : 0
            };
        }
    }
}
