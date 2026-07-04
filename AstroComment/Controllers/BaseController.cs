using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class BaseController : Controller
    {
        public bool IsLogged()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

        public bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        public IActionResult RedirectIfNotLogged()
        {
            if (!IsLogged())
                return RedirectToAction("Login", "Auth");

            return null;
        }

        public IActionResult RedirectIfNotAdmin()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Auth");

            return null;
        }
    }
}
