using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartLifeMvc.Models;
using System.Security.Claims;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class GoalProgressController : Controller
    {
        private readonly AppDbContext _context;

        public GoalProgressController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int goalId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var goal = _context.Goals.FirstOrDefault(x => x.GoalId == goalId && x.UserId == userId);
            if (goal == null)
                return NotFound();

            var list = _context.GoalProgresses
                .Where(x => x.GoalId == goalId)
                .ToList();

            ViewBag.GoalId = goalId;
            return View(list);
        }

        public IActionResult Create(int goalId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var goal = _context.Goals.FirstOrDefault(x => x.GoalId == goalId && x.UserId == userId);
            if (goal == null)
                return NotFound();

            ViewBag.GoalId = goalId;
            return View(new GoalProgress { GoalId = goalId });
        }

        [HttpPost]
        public IActionResult Create(GoalProgress model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (model.GoalId == 0)
                return BadRequest("GoalId missing");

            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == model.GoalId && x.UserId == userId);

            if (goal == null)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                model.ProgressDate = DateTime.Now;

                _context.GoalProgresses.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Details", "Goals", new { id = model.GoalId });
            }

            ViewBag.GoalId = model.GoalId;
            return View(model);
        }


        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            var progress = _context.GoalProgresses
                .Where(x => x.GoalId == id)
                .OrderByDescending(x => x.ProgressDate)
                .ToList();


            ViewBag.Progress = progress.FirstOrDefault()?.Percentage ?? 0;
            ViewBag.ProgressList = progress;

            return View(goal);
        }


        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var progress = _context.GoalProgresses
                .FirstOrDefault(x => x.GoalProgressId == id);

            if (progress == null)
                return NotFound();


            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == progress.GoalId && x.UserId == userId);

            if (goal == null)
                return Unauthorized();

            int goalId = progress.GoalId;

            _context.GoalProgresses.Remove(progress);
            _context.SaveChanges();

            return RedirectToAction("Details", "Goals", new { id = goalId });
        }
    }
}
