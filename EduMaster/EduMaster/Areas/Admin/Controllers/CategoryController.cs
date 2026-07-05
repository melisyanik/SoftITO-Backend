using Microsoft.AspNetCore.Authorization;
using EduMaster.Data.Repository;
using EduMaster.Models;
using Microsoft.AspNetCore.Mvc;

namespace EduMaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index(string search)
        {
            var list = _unitOfWork.Category.GetAll();
            
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(c => c.Name != null && c.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            ViewData["CurrentFilter"] = search;
            return View(list);
        }


        public IActionResult Crup(int? id = 0)
        {
            Category category = new();

            if (id == null || id <= 0)
            {
                return View(category);
            }

            category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        public IActionResult Crup(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id <= 0)
                {
                    _unitOfWork.Category.Add(category);
                }
                else
                {
                    _unitOfWork.Category.Update(category);
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var category = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            _unitOfWork.Category.Remove(category);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
