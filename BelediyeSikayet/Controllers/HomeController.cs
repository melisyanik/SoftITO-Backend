using BelediyeSikayet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string ilce)
    {
        var query = _context.Sikayets
            .Include(x => x.Durum)
            .Include(x => x.Cevaps)
            .AsQueryable();

        if (!string.IsNullOrEmpty(ilce))
        {
            query = query.Where(x => x.Ilce == ilce);
        }

        var list = query
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        ViewBag.Ilceler = new List<string>
    {
        "Adalar", "Arnavutköy", "Ataþehir", "Avcýlar", "Baðcýlar", "Bahçelievler",
        "Bakýrköy", "Baþakþehir", "Bayrampaþa", "Beþiktaþ", "Beykoz", "Beylikdüzü",
        "Beyoðlu", "Büyükçekmece", "Çatalca", "Çekmeköy", "Esenler", "Esenyurt",
        "Eyüpsultan", "Fatih", "Gaziosmanpaþa", "Güngören", "Kadýköy", "Kaðýthane",
        "Kartal", "Küçükçekmece", "Maltepe", "Pendik", "Sancaktepe", "Sarýyer",
        "Silivri", "Sultanbeyli", "Sultangazi", "Þile", "Þiþli", "Tuzla",
        "Ümraniye", "Üsküdar", "Zeytinburnu"
    };

        return View(list);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Kategoriler = _context.Kategoris.ToList();

        ViewBag.Ilceler = new List<string>
    {
        "Adalar", "Arnavutköy", "Ataþehir", "Avcýlar", "Baðcýlar", "Bahçelievler",
        "Bakýrköy", "Baþakþehir", "Bayrampaþa", "Beþiktaþ", "Beykoz", "Beylikdüzü",
        "Beyoðlu", "Büyükçekmece", "Çatalca", "Çekmeköy", "Esenler", "Esenyurt",
        "Eyüpsultan", "Fatih", "Gaziosmanpaþa", "Güngören", "Kadýköy", "Kaðýthane",
        "Kartal", "Küçükçekmece", "Maltepe", "Pendik", "Sancaktepe", "Sarýyer",
        "Silivri", "Sultanbeyli", "Sultangazi", "Þile", "Þiþli", "Tuzla",
        "Ümraniye", "Üsküdar", "Zeytinburnu"
    };

        return View();
    }

    [HttpPost]
    public IActionResult Create(Sikayet model)
    {
        model.DurumId = 1; 
        model.IsPublic = false;
        model.CreatedDate = DateTime.Now;

        _context.Sikayets.Add(model);
        _context.SaveChanges();

        TempData["Success"] = "Talebiniz alýnmýþtýr.";
        return RedirectToAction("Create");
    }
}