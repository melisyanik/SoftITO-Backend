using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OyunSatinAlma.DATA.Data;
using OyunSatinAlma.MODEL;

namespace OyunSatinAlma.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDBContext _context;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string sifre)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, sifre, false, false);
                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                    {
                        return RedirectToAction("Index", "Oyun");
                    }
                    return RedirectToAction("Index", "User");
                }
            }

            ViewBag.Error = "Geçersiz E-posta veya Şifre";
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Musteri model, string Sifre)
        {
            if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(Sifre) && !string.IsNullOrEmpty(model.AdSoyad))
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, Sifre);

                if (result.Succeeded)
                {
                    if (!await _userManager.IsInRoleAsync(user, "User"))
                    {
                        if (!_context.Roles.Any(r => r.Name == "User"))
                        {
                            _context.Roles.Add(new IdentityRole { Name = "User", NormalizedName = "USER" });
                            _context.SaveChanges();
                        }
                        await _userManager.AddToRoleAsync(user, "User");
                    }

                    _context.Musteriler.Add(new Musteri
                    {
                        AdSoyad = model.AdSoyad,
                        Email = model.Email,
                        Telefon = model.Telefon
                    });
                    _context.SaveChanges();

                    return RedirectToAction("Login");
                }
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
