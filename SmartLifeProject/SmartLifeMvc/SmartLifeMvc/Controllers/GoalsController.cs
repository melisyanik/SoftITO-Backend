using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartLifeMvc.Models;
using System.Security.Claims;
using SmartLifeMvc.ViewModels;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class GoalsController : Controller
    {
        private readonly AppDbContext _context;

        public GoalsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchText, string status)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var query = _context.Goals
                .Where(x => x.UserId == userId)
                .Include(x => x.GoalProgresses)
                .AsQueryable();


            if (!string.IsNullOrEmpty(searchText))
            {
                query = query.Where(x => x.Title.Contains(searchText));
            }

            var data = query.ToList();

            var result = data.Select(x => new GoalWithProgressVM
            {
                GoalId = x.GoalId,
                Title = x.Title,
                Description = x.Description,
                StartDate = x.StartDate,

                Progress = x.GoalProgresses != null && x.GoalProgresses.Any()
                    ? x.GoalProgresses.OrderByDescending(p => p.ProgressDate).First().Percentage
                    : 0
            }).ToList();


            foreach (var item in result)
            {
                if (item.Progress >= 100)
                    item.Status = "Done";
                else if (item.Progress > 0)
                    item.Status = "In Progress";
                else
                    item.Status = "Active";
            }


            if (!string.IsNullOrEmpty(status))
            {
                if (status == "Done")
                    result = result.Where(x => x.Progress >= 100).ToList();
                else if (status == "Active")
                    result = result.Where(x => x.Progress == 0).ToList();
                else if (status == "InProgress")
                    result = result.Where(x => x.Progress > 0 && x.Progress < 100).ToList();
            }

            return View(result);
        }

        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var goal = _context.Goals
                .Include(x => x.GoalProgresses)
                .FirstOrDefault(x => x.GoalId == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            var vm = new GoalDetailsVM
            {
                Goal = goal,
                ProgressList = goal.GoalProgresses?
                    .OrderByDescending(x => x.ProgressDate)
                    .ToList() ?? new List<GoalProgress>()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Goal model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                model.UserId = userId;
                model.StartDate = DateTime.Now;

                _context.Goals.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            return View(goal);
        }


        [HttpPost]
        public IActionResult Edit(Goal model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return View(model);

            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == model.GoalId && x.UserId == userId);

            if (goal == null)
                return NotFound();

            goal.Title = model.Title;
            goal.Description = model.Description;
            goal.StartDate = model.StartDate;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var goal = _context.Goals
                .FirstOrDefault(x => x.GoalId == id && x.UserId == userId);

            if (goal == null)
                return NotFound();

            _context.Goals.Remove(goal);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
