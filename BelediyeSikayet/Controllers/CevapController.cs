using BelediyeSikayet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;

using Microsoft.AspNetCore.Authorization;

[Authorize]
public class CevapController : Controller
{
    private readonly AppDbContext _context;

    public CevapController(AppDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public IActionResult Create(int sikayetId)
    {
        ViewBag.SikayetId = sikayetId;
        return View();
    }

   
    [HttpPost]
    public IActionResult Create(int sikayetId, string aciklama)
    {
        var s = _context.Sikayets.Find(sikayetId);

        if (s == null)
            return NotFound();

        var cevap = new Cevap
        {
            SikayetId = sikayetId,
            Aciklama = aciklama,
            CevapTarihi = DateTime.Now
        };

        _context.Cevaps.Add(cevap);

       
        s.DurumId = 3;

        _context.SaveChanges();

        return RedirectToAction("Index", "Cevap");
    }

   
    public IActionResult Index(string search)
    {
        var query = _context.Cevaps
            .Include(x => x.Sikayet)
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x =>
                x.Aciklama.Contains(search) ||
                x.Sikayet.Baslik.Contains(search) ||
                x.Sikayet.AdSoyad.Contains(search) ||
                x.Sikayet.Ilce.Contains(search)
            );
        }

        return View(query
            .OrderByDescending(x => x.CevapTarihi)
            .ToList());
    }

  
    [HttpGet]
    public IActionResult Update(int id)
    {
        var data = _context.Cevaps
            .Include(x => x.Sikayet)
            .FirstOrDefault(x => x.CevapId == id);

        return View(data);
    }

  
    [HttpPost]
    public IActionResult Update(Cevap model)
    {
        var data = _context.Cevaps.Find(model.CevapId);

        if (data != null)
        {
            data.Aciklama = model.Aciklama;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var data = _context.Cevaps
            .Include(x => x.Sikayet)
            .FirstOrDefault(x => x.CevapId == id);

        return View(data);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var data = _context.Cevaps.Find(id);

        if (data != null)
        {
            _context.Cevaps.Remove(data);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult ExportPdf()
    {
        var data = _context.Cevaps
            .Include(x => x.Sikayet)
            .ThenInclude(s => s.Kategori)
            .Include(x => x.Sikayet.Durum)
            .OrderByDescending(x => x.CevapTarihi)
            .ToList();

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header()
                    .Text("Cevap Raporu")
                    .FontSize(18).Bold();

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                    });

                    table.Header(h =>
                    {
                        h.Cell().Text("Şikayet").Bold();
                        h.Cell().Text("İlçe").Bold();
                        h.Cell().Text("Kategori").Bold();
                        h.Cell().Text("Durum").Bold();
                        h.Cell().Text("Cevap").Bold();
                        h.Cell().Text("Tarih").Bold();
                    });

                    foreach (var item in data)
                    {
                        table.Cell().Text(item.Sikayet?.Baslik ?? "-");
                        table.Cell().Text(item.Sikayet?.Ilce ?? "-");
                        table.Cell().Text(item.Sikayet?.Kategori?.Ad ?? "-");
                        table.Cell().Text(item.Sikayet?.Durum?.Ad ?? "-");
                        table.Cell().Text(item.Aciklama ?? "-");
                        table.Cell().Text(item.CevapTarihi.ToString("dd.MM.yyyy"));
                    }
                });
            });
        });

        var pdf = doc.GeneratePdf();
        return File(pdf, "application/pdf", "cevaplar.pdf");
    }

    public IActionResult ExportExcel()
    {
        var data = _context.Cevaps
            .Include(x => x.Sikayet)
            .ThenInclude(s => s.Kategori)
            .Include(x => x.Sikayet.Durum)
            .OrderByDescending(x => x.CevapTarihi)
            .ToList();

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Cevaplar");

      
        sheet.Cells[1, 1].Value = "Şikayet";
        sheet.Cells[1, 2].Value = "İlçe";
        sheet.Cells[1, 3].Value = "Kategori";
        sheet.Cells[1, 4].Value = "Durum";
        sheet.Cells[1, 5].Value = "Cevap";
        sheet.Cells[1, 6].Value = "Tarih";

        int row = 2;

        foreach (var item in data)
        {
            sheet.Cells[row, 1].Value = item.Sikayet?.Baslik;
            sheet.Cells[row, 2].Value = item.Sikayet?.Ilce;
            sheet.Cells[row, 3].Value = item.Sikayet?.Kategori?.Ad;
            sheet.Cells[row, 4].Value = item.Sikayet?.Durum?.Ad;
            sheet.Cells[row, 5].Value = item.Aciklama;
            sheet.Cells[row, 6].Value = item.CevapTarihi.ToString("dd.MM.yyyy HH:mm");

            row++;
        }

        sheet.Cells.AutoFitColumns();

        var stream = new MemoryStream(package.GetAsByteArray());

        return File(stream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "cevaplar.xlsx");
    }
}