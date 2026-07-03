using Microsoft.AspNetCore.Mvc;
using OyunSatinAlma.DATA.Data;

namespace OyunSatinAlma.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly ApplicationDBContext db;
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "1234")
            {
                return RedirectToAction("Index", "Rapor");
            }

            ViewBag.Error = "Hatalı kullanıcı adı veya şifre!";
            return View();
        }

        public IActionResult Index()
        {
       
            return View();
        }
    }
}