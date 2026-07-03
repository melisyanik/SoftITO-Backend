using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;
using System.IO;

namespace BiletSinema.Controllers
{
    [Authorize]
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public KategoriController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string filterType, string search)
        {
            var query = dbContext.Kategori.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                switch (filterType)
                {
                    case "KategoriNo":
                        if (int.TryParse(search, out int id))
                        {
                            query = query.Where(x => x.KategoriNo == id);
                        }
                        break;

                    case "KategoriAdi":
                        query = query.Where(x => x.KategoriAdi.Contains(search));
                        break;
                }
            }

            return View(query.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            dbContext.Kategori.Add(kategori);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var kategori = dbContext.Kategori.Find(id);

            if (kategori == null)
                return NotFound();

            return View(kategori);
        }

      
        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            dbContext.Kategori.Update(kategori);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var kategori = dbContext.Kategori.Find(id);

            if (kategori == null)
                return NotFound();

            return View(kategori);
        }

     
        [HttpPost]
        public IActionResult Delete(Kategori kategori)
        {
            var entity = dbContext.Kategori.Find(kategori.KategoriNo);

                dbContext.Kategori.Remove(entity);
                dbContext.SaveChanges();
            

                        return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var data = dbContext.Kategori.ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Kategori Raporu")
                        .SemiBold().FontSize(20);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(80);
                            columns.RelativeColumn();
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("Kategori No").Bold();
                            header.Cell().Text("Kategori Adi").Bold();
                        });

                        foreach (var item in data)
                        {
                            table.Cell().Text(item.KategoriNo.ToString());
                            table.Cell().Text(item.KategoriAdi ?? "");
                        }
                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ");
                            x.CurrentPageNumber();
                        });
                });
            });

            var bytes = pdf.GeneratePdf();
            return File(bytes, "application/pdf", "KategoriRapor.pdf");
        }

        public IActionResult ExportToExcel()
        {
            var data = dbContext.Kategori.ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Kategoriler");

                ws.Cells[1, 1].Value = "Kategori No";
                ws.Cells[1, 2].Value = "Kategori Adi";

                int row = 2;

                foreach (var item in data)
                {
                    ws.Cells[row, 1].Value = item.KategoriNo;
                    ws.Cells[row, 2].Value = item.KategoriAdi;

                    row++;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                var stream = new System.IO.MemoryStream(package.GetAsByteArray());

                return File(stream,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "KategoriRapor.xlsx");
            }
        }
    }
}