using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;

namespace BiletSinema.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public KategoriController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string filterType, string search)
        {
            var query = dbContext.Kategori.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                switch (filterType)
                {
                    case "KategoriNo":
                        if (int.TryParse(search, out int id))
                        {
                            query = query.Where(x => x.KategoriNo == id);
                        }
                        break;

                    case "KategoriAdi":
                        query = query.Where(x => x.KategoriAdi.Contains(search));
                        break;
                }
            }

            return View(query.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            dbContext.Kategori.Add(kategori);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kategori = dbContext.Kategori.Find(id);

            if (kategori == null)
                return NotFound();

            return View(kategori);
        }

      
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            dbContext.Kategori.Update(kategori);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kategori = dbContext.Kategori.Find(id);

            if (kategori == null)
                return NotFound();

            return View(kategori);
        }

     
        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            var entity = dbContext.Kategori.Find(kategori.KategoriNo);

                dbContext.Kategori.Remove(entity);
                dbContext.SaveChanges();
            

            return RedirectToAction("Index");
        }
    }
}

