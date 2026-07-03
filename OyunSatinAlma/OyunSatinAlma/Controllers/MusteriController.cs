using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OyunSatinAlma.DATA.Data;
using OyunSatinAlma.MODEL;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace OyunSatinAlma.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class MusteriController : Controller
    {
        private readonly ApplicationDBContext db;

        public MusteriController(ApplicationDBContext context)
        {
            db = context;
        }

      
        public IActionResult Index(string search)
        {
            var musteriler = db.Musteriler.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                musteriler = musteriler.Where(x =>
                    x.AdSoyad.ToLower().Contains(search.ToLower())
                );
            }

            return View(musteriler.ToList());
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Musteri m)
        {
            db.Musteriler.Add(m);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public IActionResult Update(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View(musteri);
        }

     
        [HttpPost]
        public IActionResult Update(Musteri m)
        {
            db.Musteriler.Update(m);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

      
        public IActionResult Delete(int id)
        {
            var musteri = db.Musteriler.Find(id);
            return View(musteri);
        }

      
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var musteri = db.Musteriler.Find(id);

            if (musteri != null)
            {
                db.Musteriler.Remove(musteri);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var musteriler = db.Musteriler.ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Müşteri Listesi")
                        .FontSize(20)
                        .Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.ConstantColumn(130);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").Bold();
                            header.Cell().Text("Ad Soyad").Bold();
                            header.Cell().Text("Email").Bold();
                            header.Cell().Text("Telefon").Bold();
                        });

                        foreach (var item in musteriler)
                        {
                            table.Cell().Text(item.MusteriId.ToString());
                            table.Cell().Text(item.AdSoyad ?? "");
                            table.Cell().Text(item.Email ?? "");
                            table.Cell().Text(item.Telefon ?? "");
                        }
                    });
                });
            });

            var bytes = pdf.GeneratePdf();

            return File(
                bytes,
                "application/pdf",
                "Musteriler.pdf");
        }

        public IActionResult ExportToExcel()
        {
            var musteriler = db.Musteriler.ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Musteriler");

                ws.Cells[1, 1].Value = "ID";
                ws.Cells[1, 2].Value = "Ad Soyad";
                ws.Cells[1, 3].Value = "Email";
                ws.Cells[1, 4].Value = "Telefon";

                int row = 2;

                foreach (var item in musteriler)
                {
                    ws.Cells[row, 1].Value = item.MusteriId;
                    ws.Cells[row, 2].Value = item.AdSoyad;
                    ws.Cells[row, 3].Value = item.Email;
                    ws.Cells[row, 4].Value = item.Telefon;

                    row++;
                }

                ws.Cells.AutoFitColumns();

                var content = package.GetAsByteArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Musteriler.xlsx");
            }
        }
    }
}