using EduMaster.Data.Repository;
using EduMaster.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace EduMaster.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<EduMaster.Models.User> _userManager;
        private readonly Microsoft.Extensions.Caching.Memory.IMemoryCache _memoryCache;

        public HomeController(IUnitOfWork unitOfWork, ILogger<HomeController> logger, UserManager<EduMaster.Models.User> userManager, Microsoft.Extensions.Caching.Memory.IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _memoryCache = memoryCache;
        }


        public IActionResult Index(int? categoryId, string? searchTitle)
        {

            var categories = _unitOfWork.Category.GetAll();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

            var courseList = _unitOfWork.Course.GetAll(includeProperties: "Category,Instructor").ToList();
            var courses = courseList.AsQueryable();

            if (categoryId.HasValue && categoryId > 0)
            {
                courses = courses.Where(c => c.CategoryId == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(searchTitle))
            {
                courses = courses.Where(c => c.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase));
            }

            return View(courses.ToList());
        }


        public IActionResult Details(int id)
        {
            var course = _unitOfWork.Course.GetFirstOrDefault(c => c.Id == id, includeProperties: "Category,Instructor,Comments,Comments.User");
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var course = _unitOfWork.Course.GetFirstOrDefault(c => c.Id == courseId);
            if (course == null) return NotFound();


            if (course.EnrolledCount >= course.Quota)
            {
                TempData["Error"] = "Bu kursun kontenjanı dolmuştur.";
                return RedirectToAction(nameof(Details), new { id = courseId });
            }


            var existingEnrollment = _unitOfWork.Enrollment.GetFirstOrDefault(e => e.CourseId == courseId && e.UserId == userId);
            if (existingEnrollment != null)
            {
                TempData["Info"] = "Bu kursa zaten kayıtlısınız.";
                return RedirectToAction(nameof(Details), new { id = courseId });
            }

            var enrollment = new Enrollment
            {
                CourseId = courseId,
                UserId = userId,
                EnrollDate = DateTime.Now
            };

            course.EnrolledCount++;
            
            _unitOfWork.Enrollment.Add(enrollment);
            _unitOfWork.Course.Update(course);
            _unitOfWork.Save();

            _logger.LogInformation($"Kullanıcı {userId}, Kurs {courseId}'ye kayıt oldu.");
            TempData["Success"] = "Kursa başarıyla kayıt oldunuz!";

            return RedirectToAction(nameof(Details), new { id = courseId });
        }


        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult PostComment(int courseId, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            if (!string.IsNullOrWhiteSpace(text))
            {
                var comment = new Comment
                {
                    CourseId = courseId,
                    UserId = userId,
                    Text = text,
                    CommentDate = DateTime.Now
                };

                _unitOfWork.Comment.Add(comment);
                _unitOfWork.Save();
            }

            return RedirectToAction(nameof(Details), new { id = courseId });
        }


        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult EditComment(int commentId, string text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var comment = _unitOfWork.Comment.GetFirstOrDefault(c => c.Id == commentId);
            if (comment == null) return NotFound();

            if (comment.UserId != userId && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            if (!string.IsNullOrWhiteSpace(text))
            {
                comment.Text = text;
                _unitOfWork.Comment.Update(comment);
                _unitOfWork.Save();
                TempData["Success"] = "Yorum başarıyla güncellendi.";
            }

            return RedirectToAction(nameof(Details), new { id = comment.CourseId });
        }


        [HttpPost]
        [Authorize(Roles = "User,Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteComment(int commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var comment = _unitOfWork.Comment.GetFirstOrDefault(c => c.Id == commentId);
            if (comment == null) return NotFound();

            if (comment.UserId != userId && !User.IsInRole("Admin"))
            {
                return Unauthorized();
            }

            int courseId = comment.CourseId;
            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Save();
            TempData["Success"] = "Yorum başarıyla silindi.";

            return RedirectToAction(nameof(Details), new { id = courseId });
        }
    }
}
