using Microsoft.AspNetCore.Authorization;
using EduMaster.Data.Repository;
using EduMaster.Models;
using EduMaster.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace EduMaster.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;

        public CourseController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;
        }


        public IActionResult Index()
        {
            var list = _unitOfWork.Course.GetAll(includeProperties: "Category,Instructor");
            return View(list);
        }


        public IActionResult Crup(int? id = 0)
        {
            CourseVM courseVM = new()
            {
                Course = new(),

                CategoryList = _unitOfWork.Category.GetAll()
                    .Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString()
                    }),

                InstructorList = _unitOfWork.Instructor.GetAll()
                    .Select(x => new SelectListItem
                    {
                        Text = x.FullName,
                        Value = x.Id.ToString()
                    })
            };

            if (id == null || id <= 0)
            {
                return View(courseVM);
            }

            courseVM.Course = _unitOfWork.Course
                .GetFirstOrDefault(x => x.Id == id);

            return View(courseVM);
        }


        [HttpPost]
        public IActionResult Crup(CourseVM courseVM, IFormFile file)
        {
            string wwwRootPath = _env.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"uploads\courses");
                var extension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(uploadRoot))
                {
                    Directory.CreateDirectory(uploadRoot);
                }


                if (courseVM.Course.Image != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath,
                        courseVM.Course.Image.TrimStart('\\', '/'));

                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }


                using (var fileStream = new FileStream(
                    Path.Combine(uploadRoot, fileName + extension),
                    FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                courseVM.Course.Image = @"\uploads\courses\" + fileName + extension;
            }


            if (courseVM.Course.Id <= 0)
            {
                _unitOfWork.Course.Add(courseVM.Course);
            }
            else
            {
                _unitOfWork.Course.Update(courseVM.Course);
            }

            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var course = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);

            if (course == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(course.Image))
            {
                var oldPicPath = Path.Combine(_env.WebRootPath, course.Image.TrimStart('\\', '/'));
                if (System.IO.File.Exists(oldPicPath))
                {
                    System.IO.File.Delete(oldPicPath);
                }
            }

            _unitOfWork.Course.Remove(course);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }


        public IActionResult ExportExcel()
        {
            var courses = _unitOfWork.Course.GetAll(includeProperties: "Category,Instructor").ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Kurslar");
                
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Başlık";
                worksheet.Cells[1, 3].Value = "Kategori";
                worksheet.Cells[1, 4].Value = "Eğitmen";
                worksheet.Cells[1, 5].Value = "Kontenjan Durumu";

                for (int i = 0; i < courses.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = courses[i].Id;
                    worksheet.Cells[i + 2, 2].Value = courses[i].Title;
                    worksheet.Cells[i + 2, 3].Value = courses[i].Category?.Name ?? "Bilinmiyor";
                    worksheet.Cells[i + 2, 4].Value = courses[i].Instructor?.FullName ?? "Bilinmiyor";
                    worksheet.Cells[i + 2, 5].Value = $"{courses[i].EnrolledCount} / {courses[i].Quota}";
                }

                worksheet.Cells.AutoFitColumns();
                var stream = new MemoryStream(package.GetAsByteArray());
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Kurslar.xlsx");
            }
        }


        public IActionResult ExportPdf()
        {
            var courses = _unitOfWork.Course.GetAll(includeProperties: "Category,Instructor").ToList();

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text("EduMaster - Kurs Listesi")
                        .SemiBold().FontSize(20).FontColor(Colors.Red.Medium);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(30);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.ConstantColumn(60);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").Bold();
                            header.Cell().Text("Başlık").Bold();
                            header.Cell().Text("Kategori").Bold();
                            header.Cell().Text("Eğitmen").Bold();
                            header.Cell().Text("Kontenjan").Bold();
                        });

                        foreach (var c in courses)
                        {
                            table.Cell().Text(c.Id.ToString());
                            table.Cell().Text(c.Title);
                            table.Cell().Text(c.Category?.Name ?? "N/A");
                            table.Cell().Text(c.Instructor?.FullName ?? "N/A");
                            table.Cell().Text($"{c.EnrolledCount}/{c.Quota}");
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Sayfa ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            });

            var pdfStream = new MemoryStream();
            document.GeneratePdf(pdfStream);
            pdfStream.Position = 0;

            return File(pdfStream, "application/pdf", "Kurslar.pdf");
        }


        public IActionResult Enrollments(int id)
        {
            var enrollments = _unitOfWork.Enrollment.GetAll(
                x => x.CourseId == id,
                includeProperties: "User,Course").ToList();

            var course = _unitOfWork.Course.GetFirstOrDefault(x => x.Id == id);
            ViewBag.CourseTitle = course?.Title ?? "Bilinmeyen Kurs";
            ViewBag.CourseId = id;

            return View(enrollments);
        }
    }
}
