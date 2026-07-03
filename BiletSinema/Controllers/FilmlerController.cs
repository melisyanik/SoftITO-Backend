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
    public class FilmlerController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public FilmlerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index(string filterType, string search)
        {
            var query = dbContext.Filmler
                .Include(x => x.kategori)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                switch (filterType)
                {
                    case "FilmNo":
                        if (int.TryParse(search, out int filmNo))
                        {
                            query = query.Where(x => x.FilmNo == filmNo);
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
        public IActionResult Create(Filmler film)
        {
            dbContext.Filmler.Add(film);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

     
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Kategoriler = dbContext.Kategori.ToList();

            var result = dbContext.Filmler.Find(id);
            return View(result);
        }

     
        [HttpPost]
        public IActionResult Edit(Filmler film)
        {
            dbContext.Update(film);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var film = dbContext.Filmler.Find(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Delete(Filmler film)
        {
            var entity = dbContext.Filmler.Find(film.FilmNo);

            if (entity != null)
            {
                dbContext.Filmler.Remove(entity);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var data = dbContext.Filmler
                .Include(x => x.kategori)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Film Raporu")
                        .SemiBold().FontSize(20);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(50);   
                            columns.RelativeColumn();    
                            columns.ConstantColumn(80);   
                            columns.ConstantColumn(50);  
                            columns.RelativeColumn();     
                            columns.ConstantColumn(80);  
                            columns.RelativeColumn();     
                        });

                       
                        table.Header(header =>
                        {
                            header.Cell().Text("No").Bold();
                            header.Cell().Text("Film Adý").Bold();
                            header.Cell().Text("Tarih").Bold();
                            header.Cell().Text("Puan").Bold();
                            header.Cell().Text("Yorum").Bold();
                            header.Cell().Text("Kategori No").Bold();
                            header.Cell().Text("Kategori").Bold();
                        });

                   
                        foreach (var item in data)
                        {
                            table.Cell().Text(item.FilmNo.ToString());
                            table.Cell().Text(item.Adi);
                            table.Cell().Text(item.Tarihi.ToShortDateString());
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
            return File(bytes, "application/pdf", "FilmlerRapor.pdf");
        }
        public IActionResult ExportToExcel()
        {
            var data = dbContext.Filmler
                .Include(x => x.kategori)
                .ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Filmler");

              
                ws.Cells[1, 1].Value = "Film No";
                ws.Cells[1, 2].Value = "Film Adý";
                ws.Cells[1, 3].Value = "Tarih";
                ws.Cells[1, 4].Value = "Puan";
                ws.Cells[1, 5].Value = "Yorum";
                ws.Cells[1, 6].Value = "Kategori No";
                ws.Cells[1, 7].Value = "Kategori";

                int row = 2;

                foreach (var item in data)
                {
                    ws.Cells[row, 1].Value = item.FilmNo;
                    ws.Cells[row, 2].Value = item.Adi;
                    ws.Cells[row, 3].Value = item.Tarihi.ToString("dd.MM.yyyy");
                    ws.Cells[row, 4].Value = item.Puan;
                    ws.Cells[row, 5].Value = item.Yorum;
                    ws.Cells[row, 6].Value = item.KategoriNo;
                    ws.Cells[row, 7].Value = item.kategori?.KategoriAdi;

                    row++;
                }

                ws.Cells[ws.Dimension.Address].AutoFitColumns();

                var stream = new MemoryStream(package.GetAsByteArray());

                return File(stream,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "FilmlerRapor.xlsx");
            }
        }

    }
}
