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

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploadRoot = Path.Combine(wwwRootPath, @"uploads\instructors");
                    var extension = Path.GetExtension(file.FileName);

                    if (!Directory.Exists(uploadRoot))
                    {
                        Directory.CreateDirectory(uploadRoot);
                    }


                    if (instructor.Id > 0)
                    {
                        var oldInstructor =
                            _unitOfWork.Instructor.GetFirstOrDefault(x => x.Id == instructor.Id);

                        if (oldInstructor != null &&
                            !string.IsNullOrEmpty(oldInstructor.Image))
                        {
                            var oldPicPath = Path.Combine(
                                wwwRootPath,
                                oldInstructor.Image.TrimStart('\\', '/'));

                            if (System.IO.File.Exists(oldPicPath))
                            {
                                System.IO.File.Delete(oldPicPath);
                            }
                        }
                    }

                    using (var fileStream = new FileStream(
                        Path.Combine(uploadRoot, fileName + extension),
                        FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    instructor.Image = @"\uploads\instructors\" + fileName + extension;
                }
                else
                {

                    if (instructor.Id > 0)
                    {
                        var oldInstructor =
                            _unitOfWork.Instructor.GetFirstOrDefault(x => x.Id == instructor.Id);

                        if (oldInstructor != null)
                        {
                            instructor.Image = oldInstructor.Image;
                        }
                    }
                }

                if (instructor.Id <= 0)
                {
                    _unitOfWork.Instructor.Add(instructor);
                }
                else
                {
                    _unitOfWork.Instructor.Update(instructor);
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
