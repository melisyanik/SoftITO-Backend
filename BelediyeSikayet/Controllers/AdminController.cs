using BelediyeSikayet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

[Authorize]
public class AdminController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AdminController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [AllowAnonymous]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Error = "Hatalı giriş";
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    public IActionResult Users()
    {
        var users = _userManager.Users.ToList();
        return View(users);
    }

    public IActionResult AddUser()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(string username, string email, string password)
    {
        var user = new IdentityUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(user, password);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Users");
        }

        ViewBag.Error = string.Join("<br/>", result.Errors.Select(e => e.Description));
        return View();
    }

 
    public IActionResult Index(string ilce, int? kategoriId)
    {
        var query = _context.Sikayets
            .Include(x => x.Durum)
            .Include(x => x.Kategori)
            .Include(x => x.Cevaps)
            .AsQueryable();

        if (!string.IsNullOrEmpty(ilce))
            query = query.Where(x => x.Ilce == ilce);

        if (kategoriId != null)
            query = query.Where(x => x.KategoriId == kategoriId);

        var list = query
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        ViewBag.Ilceler = _context.Sikayets.Select(x => x.Ilce).Distinct().ToList();
        ViewBag.Kategoriler = _context.Kategoris.ToList();

        ViewBag.Toplam = list.Count;
        ViewBag.Beklemede = list.Count(x => x.Durum.Ad == "Beklemede");
        ViewBag.Islemde = list.Count(x => x.Durum.Ad == "İşlemde");
        ViewBag.Cozuldu = list.Count(x => x.Durum.Ad == "Çözüldü");

        return View(list);
    }
}