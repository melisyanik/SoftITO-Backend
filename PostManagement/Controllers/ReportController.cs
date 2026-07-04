using Microsoft.AspNetCore.Mvc;
using SocialManagement.Data;
using SocialManagement.Models;

namespace SocialManagement.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReportController(ApplicationDbContext context)
        {
            this.context = context;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        // ADD REPORT IN HOMEPAGE
        [HttpPost]
        public JsonResult AddReport(string type, string reason, string postId)
        {
            int parsedPostId = 0;

            if (!string.IsNullOrEmpty(postId))
                int.TryParse(postId, out parsedPostId);

            var report = new Complaint
            {
                PostId = parsedPostId, 
                Reason = reason,
                ReporterName = "User",
                IsResolved = false,
                CreatedAt = DateTime.Now
            };

            context.Complaints.Add(report);
            context.SaveChanges();

            return Json(true);
        }
    }
    }