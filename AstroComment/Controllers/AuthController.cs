using AstroComment.Data;
using AstroComment.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;
using AstroComment.Models;

namespace AstroComment.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Username", model.LoginUsername);
            param.Add("@Password", model.LoginPassword);

            var user = Context.Query<LoginUser>("sp_UserLogin", param).FirstOrDefault();

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("Username", user.Username);

                bool isAdmin = user.Role?.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase) == true;
                HttpContext.Session.SetString("Role", isAdmin ? "Admin" : user.Role);

                if (user.Role?.Trim().Equals("Admin", StringComparison.OrdinalIgnoreCase) == true)
                    return RedirectToAction("Index", "Admin");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Hatalı kullanıcı adı veya şifre";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthViewModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Username", model.RegisterUsername);
            param.Add("@Email", model.RegisterEmail);
            param.Add("@Password", model.RegisterPassword);
            param.Add("@BirthDate", model.RegisterBirthDate);

            Context.Execute("sp_UserRegister", param);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
