using Microsoft.AspNetCore.Authorization;
using EduMaster.Data.Repository;
using EduMaster.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduMaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InstructorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public InstructorController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }

        public IActionResult Index(string search)
        {
            var instructorList = _unitOfWork.Instructor.GetAll();
            
            if (!string.IsNullOrEmpty(search))
            {
                instructorList = instructorList.Where(i => 
                    (i.FullName != null && i.FullName.Contains(search, StringComparison.OrdinalIgnoreCase)) || 
                    (i.Expertise != null && i.Expertise.Contains(search, StringComparison.OrdinalIgnoreCase))
                );
            }

            ViewData["CurrentFilter"] = search;
            return View(instructorList);
        }


        public IActionResult Crup(int? id = 0)
        {
            Instructor instructor = new();

            if (id == null || id <= 0)
            {
                return View(instructor);
            }

            instructor = _unitOfWork.Instructor.GetFirstOrDefault(x => x.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }


        [HttpPost]
        public IActionResult Crup(Instructor instructor, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _env.WebRootPath;
                Instructor existingInstructor = null;

                if (instructor.Id > 0)
                {
                    existingInstructor = _unitOfWork.Instructor.GetFirstOrDefault(x => x.Id == instructor.Id);
                }

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploadRoot = Path.Combine(wwwRootPath, @"uploads\instructors");
                    var extension = Path.GetExtension(file.FileName);

                    if (!Directory.Exists(uploadRoot))
                    {
                        Directory.CreateDirectory(uploadRoot);
                    }

                    if (existingInstructor != null && !string.IsNullOrEmpty(existingInstructor.Image))
                    {
                        var oldPicPath = Path.Combine(wwwRootPath, existingInstructor.Image.TrimStart('\\', '/'));
                        if (System.IO.File.Exists(oldPicPath))
                        {
                            System.IO.File.Delete(oldPicPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    instructor.Image = @"\uploads\instructors\" + fileName + extension;
                }
                else
                {
                    if (existingInstructor != null)
                    {
                        instructor.Image = existingInstructor.Image;
                    }
                }

                if (existingInstructor == null)
                {
                    _unitOfWork.Instructor.Add(instructor);
                }
                else
                {
                    existingInstructor.FullName = instructor.FullName;
                    existingInstructor.Expertise = instructor.Expertise;
                    existingInstructor.Image = instructor.Image;
                    _unitOfWork.Instructor.Update(existingInstructor);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(instructor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var instructor =
                _unitOfWork.Instructor.GetFirstOrDefault(x => x.Id == id);

            if (instructor == null)
            {
                return NotFound();
            }

            _unitOfWork.Instructor.Remove(instructor);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
