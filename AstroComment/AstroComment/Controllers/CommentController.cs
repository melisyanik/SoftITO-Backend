using AstroComment.Data;
using AstroComment.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index(int horoscopeId)
        {
            var param = new DynamicParameters();
            param.Add("@HoroscopeId", horoscopeId);

            var data = Context.Query<CommentVM>(
                "sp_GetCommentsWithReplies",
                param);

            return View(data);
        }

        [HttpPost]
        public IActionResult AddComment(int horoscopeId, string commentText)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Auth");

            var param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@HoroscopeId", horoscopeId);
            param.Add("@CommentText", commentText);

            Context.Execute("sp_AddComment", param);

            return RedirectToAction("Index", new { horoscopeId });
        }
    }
}
