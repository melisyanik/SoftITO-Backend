using AstroComment.Data;
using AstroComment.Models;
using AstroComment.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            return View();
        }

        public IActionResult Comments()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var data = Context.Query<CommentVM>("sp_GetAllComments");

            return View(data);
        }

        [HttpPost]
        public IActionResult Reply(int commentId, string replyText)
        {
            int? adminId =
                HttpContext.Session.GetInt32("UserId");

            if (adminId == null)
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();

            param.Add("@CommentId", commentId);
            param.Add("@AdminId", adminId);
            param.Add("@ReplyText", replyText);

            Context.Execute("sp_AddAdminReply", param);

            return RedirectToAction("Comments");
        }

        [HttpPost]
        public IActionResult EditReply(int commentId, string replyText)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@CommentId", commentId);
            param.Add("@ReplyText", replyText);

            Context.Execute("UPDATE Comments SET ReplyText = @ReplyText, ReplyDate = GETDATE() WHERE CommentId = @CommentId", param, System.Data.CommandType.Text);

            return RedirectToAction("Comments");
        }

        [HttpPost]
        public IActionResult DeleteReply(int commentId)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@CommentId", commentId);

            Context.Execute("UPDATE Comments SET ReplyText = NULL, ReplyDate = NULL, AdminId = NULL WHERE CommentId = @CommentId", param, System.Data.CommandType.Text);

            return RedirectToAction("Comments");
        }

        public IActionResult Horoscopes()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var horoscopes = Context.Query<HoroscopeVM>("SELECT h.HoroscopeId, h.ZodiacId, h.Content, h.HoroscopeDate, z.Name as ZodiacName FROM Horoscopes h JOIN ZodiacSigns z ON h.ZodiacId = z.ZodiacId ORDER BY h.HoroscopeDate DESC", commandType: System.Data.CommandType.Text);
            return View(horoscopes);
        }

        public IActionResult CreateHoroscope()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var zodiacs = Context.Query<ZodiacModel>("sp_GetAllZodiacs");
            ViewBag.Zodiacs = zodiacs;
            return View();
        }

        [HttpPost]
        public IActionResult CreateHoroscope(HoroscopeVM model)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@ZodiacId", model.ZodiacId);
            param.Add("@Content", model.Content);
            param.Add("@HoroscopeDate", model.HoroscopeDate);

            Context.Execute("INSERT INTO Horoscopes (ZodiacId, Content, HoroscopeDate) VALUES (@ZodiacId, @Content, @HoroscopeDate)", param, System.Data.CommandType.Text);

            return RedirectToAction("Horoscopes");
        }

        public IActionResult EditHoroscope(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@Id", id);

            var horoscope = Context.Query<HoroscopeVM>("SELECT * FROM Horoscopes WHERE HoroscopeId = @Id", param, System.Data.CommandType.Text).FirstOrDefault();
            
            if (horoscope == null) return NotFound();

            var zodiacs = Context.Query<ZodiacModel>("sp_GetAllZodiacs");
            ViewBag.Zodiacs = zodiacs;

            return View(horoscope);
        }

        [HttpPost]
        public IActionResult EditHoroscope(HoroscopeVM model)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@HoroscopeId", model.HoroscopeId);
            param.Add("@ZodiacId", model.ZodiacId);
            param.Add("@Content", model.Content);
            param.Add("@HoroscopeDate", model.HoroscopeDate);

            Context.Execute("UPDATE Horoscopes SET ZodiacId = @ZodiacId, Content = @Content, HoroscopeDate = @HoroscopeDate WHERE HoroscopeId = @HoroscopeId", param, System.Data.CommandType.Text);

            return RedirectToAction("Horoscopes");
        }

        public IActionResult DeleteHoroscope(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            DynamicParameters param = new();
            param.Add("@Id", id);

            Context.Execute("DELETE FROM Horoscopes WHERE HoroscopeId = @Id", param, System.Data.CommandType.Text);

            return RedirectToAction("Horoscopes");
        }
    }
}
