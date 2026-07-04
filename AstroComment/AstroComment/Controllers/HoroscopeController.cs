using AstroComment.Data;
using AstroComment.ViewModels;
using AstroComment.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class HoroscopeController : Controller
    {
        public IActionResult Detail(int id)
        {
            var param = new DynamicParameters();
            param.Add("@ZodiacId", id);

            var horoscope = Context.Query<HoroscopeVM>(
                "sp_GetDailyHoroscope", param
            ).FirstOrDefault();

            if (horoscope == null)
            {
                var zodiacs = Context.Query<ZodiacModel>("sp_GetAllZodiacs");
                var zodiac = zodiacs.FirstOrDefault(z => z.ZodiacId == id);

                horoscope = new HoroscopeVM
                {
                    HoroscopeId = 0,
                    ZodiacId = id,
                    ZodiacName = zodiac?.Name ?? "Bilinmeyen",
                    Content = "Bu burç için henüz günlük yorum girilmemiş.",
                    HoroscopeDate = DateTime.Today
                };
            }

            var commentParam = new DynamicParameters();
            commentParam.Add("@HoroscopeId", horoscope.HoroscopeId);

            var comments = Context.Query<CommentVM>(
                "sp_GetCommentsWithReplies", commentParam
            );

            ViewBag.Comments = comments;

            return View(horoscope);
        }
    }
}
