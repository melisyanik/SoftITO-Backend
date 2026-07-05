using Microsoft.AspNetCore.Authorization;
using EduMaster.Data.Repository;
using EduMaster.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EduMaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index(string search)
        {
            var list = _unitOfWork.Comment.GetAll(includeProperties: "Course,User");
            
            if (!string.IsNullOrEmpty(search))
            {
                list = list.Where(c => (c.Text != null && c.Text.Contains(search, StringComparison.OrdinalIgnoreCase)) || 
                                       (c.User != null && c.User.Email != null && c.User.Email.Contains(search, StringComparison.OrdinalIgnoreCase)) || 
                                       (c.Course != null && c.Course.Title != null && c.Course.Title.Contains(search, StringComparison.OrdinalIgnoreCase)));
            }

            ViewData["CurrentFilter"] = search;
            return View(list);
        }


        public IActionResult Crup(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var comment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == id, includeProperties: "Course,User");

            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }


        [HttpPost]
        public IActionResult Crup(Comment comment)
        {
            if (comment.Id > 0)
            {
                var existingComment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == comment.Id);
                if (existingComment != null)
                {
                    existingComment.Text = comment.Text;
                    _unitOfWork.Comment.Update(existingComment);
                    _unitOfWork.Save();
                }
            }
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var comment = _unitOfWork.Comment.GetFirstOrDefault(x => x.Id == id);

            if (comment == null)
            {
                return NotFound();
            }

            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }
    }
}
