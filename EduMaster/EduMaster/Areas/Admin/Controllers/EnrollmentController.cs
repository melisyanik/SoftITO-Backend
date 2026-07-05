using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EduMaster.Data.Repository;
using EduMaster.Models;
using System.Security.Claims;

namespace EduMaster.Areas.User.Controllers
{
    [Area("User")]
    public class EnrollmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EnrollmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Enroll(int courseId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var course = _unitOfWork.Course
                .GetFirstOrDefault(x => x.Id == courseId);

            if (course == null)
            {
                return NotFound();
            }


            if (course.EnrolledCount >= course.Quota)
            {
                return Content("Kontenjan dolu");
            }

            Enrollment enrollment = new()
            {
                CourseId = courseId,
                UserId = userId
            };

            _unitOfWork.Enrollment.Add(enrollment);


            course.EnrolledCount++;

            _unitOfWork.Course.Update(course);

            _unitOfWork.Save();

            return RedirectToAction("MyCourses");
        }

        public IActionResult MyCourses()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var list = _unitOfWork.Enrollment
                .GetAll(x => x.UserId == userId);

            return View(list);
        }
    }
}
