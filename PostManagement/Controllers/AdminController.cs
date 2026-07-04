using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SocialManagement.Data;
using SocialManagement.Models;
using System.Linq;

namespace SocialManagement.Controllers
{
    public class AdminController : Controller
    {
   

        private readonly ApplicationDbContext context;

        private const string USER = "admin";
        private const string PASS = "123";

        public AdminController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // LOGIN
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == USER && password == PASS)
                return RedirectToAction("Index");

            ViewBag.Error = "Hatalı giriş";
            return View();
        }

        // DASHBOARD
        public IActionResult Index()
        {
            ViewBag.PostCount = context.Posts.Count();
            ViewBag.ComplaintCount = context.Complaints.Count();
            ViewBag.LogCount = context.ActivityLogs.Count();

            return View();
        }

        // POSTS

        public IActionResult Posts()
        {
            return View();
        }

        public JsonResult PostList()
        {
            var data = context.Posts
                .OrderByDescending(x => x.Id)
                .ToList();

            return Json(data);
        }

        public JsonResult GetPost(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);
            return Json(post);
        }


        [HttpPost]
        public JsonResult AddPost(Post post)
        {
            post.CreatedAt = DateTime.Now;
            context.Posts.Add(post);
            context.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public JsonResult UpdatePost(Post post)
        {
            var data = context.Posts.FirstOrDefault(x => x.Id == post.Id);

            if (data == null) return Json(false);

            data.Title = post.Title;
            data.Content = post.Content;
            data.ImageUrl = post.ImageUrl;
            data.Tag = post.Tag;
            data.AuthorName = post.AuthorName;

            context.SaveChanges();

            return Json(true);
        }

        public JsonResult DeletePost(int id)
        {
            var post = context.Posts.FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                context.Posts.Remove(post);
                context.SaveChanges();
            }

            return Json(true);
        }

        public JsonResult SearchPost(string field, string value)
        {
            var query = context.Posts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.ToLower();

                switch (field)
                {
                    case "Id":
                        if (int.TryParse(value, out int id))
                            query = query.Where(x => x.Id == id);
                        break;

                    case "Title":
                        query = query.Where(x => x.Title != null && x.Title.ToLower().Contains(value));
                        break;

                    case "Content":
                        query = query.Where(x => x.Content != null && x.Content.ToLower().Contains(value));
                        break;

                    case "AuthorName":
                        query = query.Where(x => x.AuthorName != null && x.AuthorName.ToLower().Contains(value));
                        break;

                    case "Tag":
                        query = query.Where(x => x.Tag != null && x.Tag.ToLower().Contains(value));
                        break;
                }
            }

            return Json(query.OrderByDescending(x => x.Id).ToList());
        }

        public IActionResult ExportPostsPdf()
        {
            var posts = context.Posts
                .OrderByDescending(x => x.Id)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);

                    page.Header()
                        .Text("POSTS REPORT")
                        .FontSize(20)
                        .Bold();

                    page.Content()
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  
                                columns.RelativeColumn(2);   
                                columns.RelativeColumn(3);    
                                columns.RelativeColumn(2);   
                                columns.ConstantColumn(80);  
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Title").Bold();
                                header.Cell().Text("Content").Bold();
                                header.Cell().Text("Author").Bold();
                                header.Cell().Text("Date").Bold();
                            });

                            foreach (var p in posts)
                            {
                                table.Cell().Text(p.Id.ToString());
                                table.Cell().Text(p.Title ?? "");
                                table.Cell().Text(p.Content ?? "");
                                table.Cell().Text(p.AuthorName ?? "");
                                table.Cell().Text(p.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                            }
                        });
                });
            });

            return File(pdf.GeneratePdf(), "application/pdf",
                $"Posts_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportPostsExcel()
        {
            var posts = context.Posts
                .OrderByDescending(x => x.Id)
                .ToList();

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Posts");

            ws.Cells[1, 1].Value = "Id";
            ws.Cells[1, 2].Value = "Title";
            ws.Cells[1, 3].Value = "Content";
            ws.Cells[1, 4].Value = "Author";
            ws.Cells[1, 5].Value = "Date";

            int row = 2;

            foreach (var p in posts)
            {
                ws.Cells[row, 1].Value = p.Id;
                ws.Cells[row, 2].Value = p.Title;
                ws.Cells[row, 3].Value = p.Content;
                ws.Cells[row, 4].Value = p.AuthorName;
                ws.Cells[row, 5].Value = p.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                row++;
            }

            ws.Cells.AutoFitColumns();

            return File(package.GetAsByteArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Posts_{DateTime.Now:yyyyMMdd}.xlsx");
        }



        // COMPLAINTS

        public IActionResult Complaints()
        {
            return View();
        }

        public JsonResult ComplaintList()
        {
            return Json(
                context.Complaints
                .OrderByDescending(x => x.Id)
                .ToList()
            );
        }

        [HttpPost]
        public JsonResult AddComplaint([FromBody] Complaint model)
        {
            if (model == null) return Json(false);

            model.CreatedAt = DateTime.Now;
            model.IsResolved = false;

            context.Complaints.Add(model);
            context.SaveChanges();

            return Json(true);
        }

        public JsonResult GetComplaint(int id)
        {
            var data = context.Complaints.FirstOrDefault(x => x.Id == id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult UpdateComplaint([FromBody] Complaint model)
        {
            var data = context.Complaints.FirstOrDefault(x => x.Id == model.Id);

            if (data == null) return Json(false);

            data.PostId = model.PostId;
            data.Reason = model.Reason;
            data.ReporterName = model.ReporterName;
            data.IsResolved = model.IsResolved;

            context.SaveChanges();

            return Json(true);
        }

        public JsonResult DeleteComplaint(int id)
        {
            var data = context.Complaints.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                context.Complaints.Remove(data);
                context.SaveChanges();
            }

            return Json(true);
        }

        
        public JsonResult SearchComplaint(string field, string value)
        {
            var q = context.Complaints.AsQueryable();

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.ToLower();

                switch (field)
                {
                    case "Id":
                        if (int.TryParse(value, out int id))
                            q = q.Where(x => x.Id == id);
                        break;

                    case "Reason":
                        q = q.Where(x => x.Reason.ToLower().Contains(value));
                        break;

                    case "Reporter":
                        q = q.Where(x => x.ReporterName.ToLower().Contains(value));
                        break;

                    case "PostId":
                        q = q.Where(x => x.PostId.ToString().Contains(value));
                        break;

                    case "Status":
                        bool st = value == "true";
                        q = q.Where(x => x.IsResolved == st);
                        break;
                }
            }

            return Json(q.OrderByDescending(x => x.Id).ToList());
        }

        [HttpPost]
        public JsonResult ToggleComplaintStatus(int id)
        {
            var data = context.Complaints.FirstOrDefault(x => x.Id == id);

            if (data == null) return Json(false);

            data.IsResolved = !data.IsResolved;
            context.SaveChanges();

            return Json(true);
        }

        public IActionResult ExportComplaintsPdf()
        {
            var complaints = context.Complaints
                .OrderByDescending(x => x.Id)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10));

                   
                    page.Header()
                        .Text("Complaints Report")
                        .SemiBold()
                        .FontSize(20)
                        .FontColor(Colors.Red.Medium);

                    
                    page.Content()
                        .PaddingTop(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40);  
                                columns.RelativeColumn(2);   
                                columns.RelativeColumn(2);   
                                columns.ConstantColumn(80); 
                                columns.ConstantColumn(60);  
                                columns.ConstantColumn(60);  
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Reason").Bold();
                                header.Cell().Text("Reporter").Bold();
                                header.Cell().Text("Date").Bold();
                                header.Cell().Text("PostId").Bold();
                                header.Cell().Text("Resolved").Bold();
                            });

                            foreach (var c in complaints)
                            {
                                table.Cell().Text(c.Id.ToString());
                                table.Cell().Text(c.Reason ?? "");
                                table.Cell().Text(c.ReporterName ?? "");
                                table.Cell().Text(
    c.CreatedAt == default
        ? "-"
        : c.CreatedAt.ToString("yyyy-MM-dd HH:mm")
);
                                table.Cell().Text(c.PostId.ToString());
                                table.Cell().Text(c.IsResolved ? "Yes" : "No");
                            }
                        });
                });
            });

            var bytes = pdf.GeneratePdf();

            return File(bytes, "application/pdf",
                $"Complaints_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportComplaintsExcel()
        {
            var data = context.Complaints
                .OrderByDescending(x => x.Id)
                .ToList();

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Complaints");

            ws.Cells[1, 1].Value = "Id";
            ws.Cells[1, 2].Value = "PostId";
            ws.Cells[1, 3].Value = "Reason";
            ws.Cells[1, 4].Value = "Reporter";
            ws.Cells[1, 5].Value = "Status";
            ws.Cells[1, 6].Value = "Created Date"; 

            int row = 2;

            foreach (var c in data)
            {
                ws.Cells[row, 1].Value = c.Id;
                ws.Cells[row, 2].Value = c.PostId;
                ws.Cells[row, 3].Value = c.Reason;
                ws.Cells[row, 4].Value = c.ReporterName;
                ws.Cells[row, 5].Value = c.IsResolved ? "Resolved" : "Pending";
                ws.Cells[row, 6].Value = c.CreatedAt.ToString("yyyy-MM-dd HH:mm"); 

                row++;
            }

            ws.Cells.AutoFitColumns();

            return File(
                package.GetAsByteArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Complaints_{DateTime.Now:yyyyMMdd}.xlsx"
            );
        }

        // LOGS

        public IActionResult Logs()
        {
            return View();
        }

        public JsonResult LogList()
        {
            return Json(context.ActivityLogs.OrderByDescending(x => x.Id).ToList());
        }

        public JsonResult GetLog(int id)
        {
            var data = context.ActivityLogs.FirstOrDefault(x => x.Id == id);
            return Json(data);
        }

        [HttpPost]
        public JsonResult AddLog([FromBody] ActivityLog model)
        {
            if (model == null) return Json(false);

            model.CreatedAt = DateTime.Now;

            context.ActivityLogs.Add(model);
            context.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public JsonResult UpdateLog([FromBody] ActivityLog model)
        {
            var data = context.ActivityLogs.FirstOrDefault(x => x.Id == model.Id);

            if (data != null)
            {
                data.Action = model.Action;
                data.Detail = model.Detail;
                context.SaveChanges();
            }

            return Json(true);
        }

        public JsonResult DeleteLog(int id)
        {
            var data = context.ActivityLogs.FirstOrDefault(x => x.Id == id);

            if (data != null)
            {
                context.ActivityLogs.Remove(data);
                context.SaveChanges();
            }

            return Json(true);
        }

        public JsonResult SearchLog(string field, string value)
        {
            var query = context.ActivityLogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(value))
            {
                value = value.ToLower();

                if (field == "Id")
                    query = query.Where(x => x.Id.ToString() == value);

                else if (field == "Action")
                    query = query.Where(x => x.Action.ToLower().Contains(value));

                else if (field == "Detail")
                    query = query.Where(x => x.Detail.ToLower().Contains(value));
            }

            return Json(query.OrderByDescending(x => x.Id).ToList());
        }
        public IActionResult ExportLogsPdf()
        {
            var logs = context.ActivityLogs
                .OrderByDescending(x => x.Id)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(10));

                 
                    page.Header()
                        .Text("Activity Logs Report")
                        .SemiBold()
                        .FontSize(20)
                        .FontColor(Colors.Blue.Medium);

                  
                    page.Content()
                        .PaddingTop(1, Unit.Centimetre)
                        .Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(40); 
                                columns.RelativeColumn(2);    
                                columns.RelativeColumn(4);    
                                columns.ConstantColumn(80);   
                            });

                            table.Header(header =>
                            {
                                header.Cell().Text("ID").Bold();
                                header.Cell().Text("Action").Bold();
                                header.Cell().Text("Detail").Bold();
                                header.Cell().Text("Date").Bold();
                            });

                            foreach (var l in logs)
                            {
                                table.Cell().Text(l.Id.ToString());
                                table.Cell().Text(l.Action ?? "");
                                table.Cell().Text(l.Detail ?? "");
                                table.Cell().Text(l.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
                            }
                        });
                });
            });

            var bytes = pdf.GeneratePdf();

            return File(bytes, "application/pdf",
                $"Logs_{DateTime.Now:yyyyMMdd}.pdf");
        }

        public IActionResult ExportLogsExcel()
        {
            var logs = context.ActivityLogs
                .OrderByDescending(x => x.Id)
                .ToList();

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add("Logs");

            ws.Cells[1, 1].Value = "Id";
            ws.Cells[1, 2].Value = "Created Date";
            ws.Cells[1, 3].Value = "Action";
            ws.Cells[1, 4].Value = "Detail";

            int row = 2;

            foreach (var item in logs)
            {
                ws.Cells[row, 1].Value = item.Id;
                ws.Cells[row, 2].Value = item.CreatedAt.ToString("yyyy-MM-dd HH:mm");
                ws.Cells[row, 3].Value = item.Action;
                ws.Cells[row, 4].Value = item.Detail;
                row++;
            }

            ws.Cells.AutoFitColumns();

            return File(
                package.GetAsByteArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Logs_{DateTime.Now:yyyyMMdd}.xlsx"
            );
        }
    }
}