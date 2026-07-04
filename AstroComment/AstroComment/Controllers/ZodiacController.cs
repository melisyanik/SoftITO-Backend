using AstroComment.Data;
using AstroComment.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AstroComment.Controllers
{
    public class ZodiacController : Controller
    {
        public IActionResult Index()
        {
            var data = Context.Query<ZodiacSign>("sp_GetAllZodiacSigns");
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ZodiacSign zodiac)
        {
            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", zodiac.Name);
                parameters.Add("@StartDate", zodiac.StartDate);
                parameters.Add("@EndDate", zodiac.EndDate);
                parameters.Add("@Element", zodiac.Element);
                
                Context.Execute("sp_InsertZodiacSign", parameters);
                return RedirectToAction("Index");
            }
            return View(zodiac);
        }

        public IActionResult Edit(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ZodiacId", id);
            var zodiac = Context.Query<ZodiacSign>("sp_GetZodiacSignById", parameters).FirstOrDefault();
            
            if (zodiac == null)
            {
                return NotFound();
            }
            return View(zodiac);
        }

        [HttpPost]
        public IActionResult Edit(ZodiacSign zodiac)
        {
            if (ModelState.IsValid)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ZodiacId", zodiac.ZodiacId);
                parameters.Add("@Name", zodiac.Name);
                parameters.Add("@StartDate", zodiac.StartDate);
                parameters.Add("@EndDate", zodiac.EndDate);
                parameters.Add("@Element", zodiac.Element);
                
                Context.Execute("sp_UpdateZodiacSign", parameters);
                return RedirectToAction("Index");
            }
            return View(zodiac);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ZodiacId", id);
            Context.Execute("sp_DeleteZodiacSign", parameters);
            return RedirectToAction("Index");
        }
    }
}
