using Microsoft.AspNetCore.Authorization;
using BiletSinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;


namespace BiletSinema.Controllers
{
    [Authorize]
    public class TiyatrolarController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TiyatrolarController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string filterType, string search)
        {
            var query = dbContext.Tiyatrolar
                .Include(x => x.kategori)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                switch (filterType)
                {
                    case "TiyatroNo":
                        if (int.TryParse(search, out int tiyatroNo))
                        {
                            query = query.Where(x => x.TiyatroNo == tiyatroNo);
                        }
                        break;

                    case "Adi":
                        query = query.Where(x => x.Adi.Contains(search));
                        break;

                    case "Tarihi":
                        if (DateTime.TryParse(search, out DateTime tarih))
                        {
                            query = query.Where(x => x.Tarihi.Date == tarih.Date);
                        }
                        break;

                    case "YazarAdi":
                        query = query.Where(x => x.YazarAdi.Contains(search));
                        break;

                    case "Sure":
                        if (int.TryParse(search, out int sure))
                        {
                            query = query.Where(x => x.Sure == sure);
                        }
                        break;

                    case "Yorum":
                        query = query.Where(x => x.Yorum.Contains(search));
                        break;

                    case "KategoriNo":
                        if (int.TryParse(search, out int kategoriNo))
                        {
                            query = query.Where(x => x.KategoriNo == kategoriNo);
                        }
                        break;

                    case "Kategori":
                        query = query.Where(x => x.kategori.KategoriAdi.Contains(search));
                        break;
                }
            }

            return View(query.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Kategoriler = dbContext.Kategori.ToList();
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Tiyatrolar tiyatro)
        {
            dbContext.Tiyatrolar.Add(tiyatro);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Kategoriler = dbContext.Kategori.ToList();

            var tiyatro = dbContext.Tiyatrolar
                .FirstOrDefault(x => x.TiyatroNo == id);

            if (tiyatro == null)
                return NotFound();

            return View(tiyatro);
        }

       
        [HttpPost]
        public IActionResult Edit(Tiyatrolar model)
        {
            dbContext.Update(model);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

   
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tiyatro = dbContext.Tiyatrolar
                .Include(x => x.kategori)
                .FirstOrDefault(x => x.TiyatroNo == id);

            if (tiyatro == null)
                return NotFound();

            return View(tiyatro);
        }

 
        [HttpPost]
        public IActionResult Delete(Tiyatrolar model)
        {
            var entity = dbContext.Tiyatrolar
                .FirstOrDefault(x => x.TiyatroNo == model.TiyatroNo);

            if (entity != null)
            {
                dbContext.Tiyatrolar.Remove(entity);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var data = dbContext.Tiyatrolar
                .Include(x => x.kategori)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Tiyatro Raporu")
                        .SemiBold().FontSize(20);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);
                            columns.RelativeColumn();  
                            columns.ConstantColumn(80);   
                            columns.RelativeColumn();     
                            columns.ConstantColumn(60);   
                            columns.ConstantColumn(50);
                            columns.RelativeColumn();   
                            columns.ConstantColumn(80);   
                            columns.RelativeColumn();   
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("No").Bold();
                            header.Cell().Text("Tiyatro Adý").Bold();
                            header.Cell().Text("Tarih").Bold();
                            header.Cell().Text("Yazar").Bold();
                            header.Cell().Text("Süre").Bold();
                            header.Cell().Text("Puan").Bold();
                            header.Cell().Text("Yorum").Bold();
                            header.Cell().Text("Kategori No").Bold();
                            header.Cell().Text("Kategori").Bold();
                        });

                        foreach (var item in data)
                        {
                            table.Cell().Text(item.TiyatroNo.ToString());
                            table.Cell().Text(item.Adi);
                            table.Cell().Text(item.Tarihi.ToShortDateString());
                            table.Cell().Text(item.YazarAdi);
                            table.Cell().Text(item.Sure.ToString());
                            table.Cell().Text(item.Puan.ToString());
                            table.Cell().Text(item.Yorum ?? "-");
                            table.Cell().Text(item.KategoriNo.ToString());
                            table.Cell().Text(item.kategori?.KategoriAdi ?? "Yok");
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
            return File(bytes, "application/pdf", "TiyatrolarRapor.pdf");
        }

        public IActionResult ExportToExcel()
        {
            var data = dbContext.Tiyatrolar
                .Include(x => x.kategori)
                .ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Tiyatrolar");

                ws.Cells[1, 1].Value = "Tiyatro No";
                ws.Cells[1, 2].Value = "Adý";
                ws.Cells[1, 3].Value = "Tarih";
                ws.Cells[1, 4].Value = "Yazar";
                ws.Cells[1, 5].Value = "Süre";
                ws.Cells[1, 6].Value = "Puan";
                ws.Cells[1, 7].Value = "Yorum";
                ws.Cells[1, 8].Value = "Kategori No";
                ws.Cells[1, 9].Value = "Kategori";

                int row = 2;

                foreach (var item in data)
                {
                    ws.Cells[row, 1].Value = item.TiyatroNo;
                    ws.Cells[row, 2].Value = item.Adi;
                    ws.Cells[row, 3].Value = item.Tarihi.ToString("dd.MM.yyyy");
                    ws.Cells[row, 4].Value = item.YazarAdi;
                    ws.Cells[row, 5].Value = item.Sure;
                    ws.Cells[row, 6].Value = item.Puan;
                    ws.Cells[row, 7].Value = item.Yorum;
                    ws.Cells[row, 8].Value = item.KategoriNo;
                    ws.Cells[row, 9].Value = item.kategori?.KategoriAdi;

                    row++;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());

                return File(stream,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "TiyatrolarRapor.xlsx");
            }
        }
    }
}
