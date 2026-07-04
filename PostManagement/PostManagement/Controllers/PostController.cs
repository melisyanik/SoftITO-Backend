using Microsoft.AspNetCore.Mvc;
using SocialManagement.Data;
using SocialManagement.Models;

namespace SocialManagement.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext context;

        public PostController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // CREATE POSTS IN HOMEPAGE
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult PostList()
        {
            var data = context.Posts.ToList();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult AddPost(Post post)
        {
            var p = new Post()
            {
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                Tag = post.Tag,
                AuthorName = post.AuthorName
            };

            context.Posts.Add(p);
            context.SaveChanges();

            return new JsonResult("Saved");
        }

        public JsonResult Edit(int id)
        {
            var data = context.Posts.Where(x => x.Id == id).SingleOrDefault();
            return new JsonResult(data);
        }

        [HttpPost]
        public JsonResult Update(Post post)
        {
            context.Posts.Update(post);
            context.SaveChanges();

            return new JsonResult("Updated");
        }

        public JsonResult Delete(int id)
        {
            var data = context.Posts.Where(x => x.Id == id).SingleOrDefault();
            context.Posts.Remove(data);
            context.SaveChanges();

            return new JsonResult("Deleted");
        }

        public JsonResult Search(string keyword)
        {
            var data = context.Posts
                .Where(x =>
                    x.Title.Contains(keyword) ||
                    x.Content.Contains(keyword) ||
                    x.Tag.Contains(keyword) ||
                    x.AuthorName.Contains(keyword)
                )
                .ToList();

            return Json(data);
        }

        [HttpPost]
        public JsonResult ReportPost(int postId, string reason)
        {
            Complaint complaint = new Complaint
            {
                PostId = postId,
                Reason = reason,
                ReporterName = "Anonymous",
                IsResolved = false,
                CreatedAt = DateTime.Now
            };

            context.Complaints.Add(complaint);
            context.SaveChanges();

            return Json(true);
        }
    }
}