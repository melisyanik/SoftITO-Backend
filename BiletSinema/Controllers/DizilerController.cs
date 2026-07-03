using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiletSinema.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;

namespace BiletSinema.Controllers
{
    [Authorize]
    public class DizilerController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DizilerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string filterType, string search)
        {
            var query = dbContext.Diziler
                .Include(x => x.kategori)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                switch (filterType)
                {
                    case "DiziNo":
                        if (int.TryParse(search, out int diziNo))
                        {
                            query = query.Where(x => x.DiziNo == diziNo);
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

                    case "BolumSayisi":
                        if (int.TryParse(search, out int bolumSayisi))
                        {
                            query = query.Where(x => x.BolumSayisi == bolumSayisi);
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
        public IActionResult Create(Diziler dizi)
        {
            dbContext.Diziler.Add(dizi);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Kategoriler = dbContext.Kategori.ToList();

            var dizi = dbContext.Diziler
                .FirstOrDefault(x => x.DiziNo == id);

            if (dizi == null)
                return NotFound();

            return View(dizi);
        }


        [HttpPost]
        public IActionResult Edit(Diziler dizi)
        {

            dbContext.Diziler.Update(dizi);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dizi = dbContext.Diziler
                .Include(x => x.kategori)
                .FirstOrDefault(x => x.DiziNo == id);

            if (dizi == null)
                return NotFound();

            return View(dizi);
        }

     
        [HttpPost]
        public IActionResult Delete(Diziler dizi)
        {
            var entity = dbContext.Diziler.Find(dizi.DiziNo);

            if (entity != null)
            {
                dbContext.Diziler.Remove(entity);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var data = dbContext.Diziler
                .Include(x => x.kategori)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Dizi Raporu")
                        .SemiBold().FontSize(20);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);   
                            columns.RelativeColumn();     
                            columns.ConstantColumn(80);  
                            columns.ConstantColumn(60); 
                            columns.RelativeColumn();    
                            columns.ConstantColumn(80);  
                            columns.RelativeColumn();   
                        });

                    
                        table.Header(header =>
                        {
                            header.Cell().Text("No").Bold();
                            header.Cell().Text("Dizi Adý").Bold();
                            header.Cell().Text("Tarih").Bold();
                            header.Cell().Text("Bölüm Sayýsý").Bold();
                            header.Cell().Text("Yorum").Bold();
                            header.Cell().Text("Kategori No").Bold();
                            header.Cell().Text("Kategori").Bold();
                        });

                
                        foreach (var item in data)
                        {
                            table.Cell().Text(item.DiziNo.ToString());
                            table.Cell().Text(item.Adi);
                            table.Cell().Text(item.Tarihi.ToShortDateString());
                            table.Cell().Text(item.BolumSayisi.ToString());
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
            return File(bytes, "application/pdf", "DizilerRapor.pdf");
        }

        public IActionResult ExportToExcel()
        {
            var data = dbContext.Diziler
                .Include(x => x.kategori)
                .ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Diziler");

               
                ws.Cells[1, 1].Value = "Dizi No";
                ws.Cells[1, 2].Value = "Dizi Adý";
                ws.Cells[1, 3].Value = "Tarih";
                ws.Cells[1, 4].Value = "Bölüm Sayýsý";
                ws.Cells[1, 5].Value = "Yorum";
                ws.Cells[1, 6].Value = "Kategori No";
                ws.Cells[1, 7].Value = "Kategori";

                int row = 2;

                foreach (var item in data)
                {
                    ws.Cells[row, 1].Value = item.DiziNo;
                    ws.Cells[row, 2].Value = item.Adi;
                    ws.Cells[row, 3].Value = item.Tarihi.ToString("dd.MM.yyyy");
                    ws.Cells[row, 4].Value = item.BolumSayisi;
                    ws.Cells[row, 5].Value = item.Yorum;
                    ws.Cells[row, 6].Value = item.KategoriNo;
                    ws.Cells[row, 7].Value = item.kategori?.KategoriAdi;

                    row++;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());

                return File(stream,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "DizilerRapor.xlsx");
            }
        }

    }
}
