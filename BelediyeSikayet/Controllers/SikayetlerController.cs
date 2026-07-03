using BelediyeSikayet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

using Microsoft.AspNetCore.Authorization;

[Authorize]
public class SikayetlerController : Controller
{
    private readonly AppDbContext _context;

    public SikayetlerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string field, string value)
    {
        var query = _context.Sikayets
            .Include(x => x.Durum)
            .Include(x => x.Kategori)
            .Include(x => x.Cevaps)
            .AsQueryable();

        if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(value))
        {
            switch (field)
            {
                case "adsoyad":
                    query = query.Where(x => x.AdSoyad.Contains(value));
                    break;

                case "telefon":
                    query = query.Where(x => x.Telefon.Contains(value));
                    break;

                case "email":
                    query = query.Where(x => x.Email.Contains(value));
                    break;

                case "ilce":
                    query = query.Where(x => x.Ilce.Contains(value));
                    break;

                case "kategori":
                    query = query.Where(x => x.Kategori.Ad.Contains(value));
                    break;

                case "baslik":
                    query = query.Where(x => x.Baslik.Contains(value));
                    break;
            }
        }

        ViewBag.Fields = new List<string>
        {
            "adsoyad","telefon","email","ilce","kategori","baslik"
        };

        return View(query.OrderByDescending(x => x.CreatedDate).ToList());
    }

    public IActionResult DurumDegistir(int id, int durumId)
    {
        var data = _context.Sikayets.Find(id);

        if (data != null)
        {
            data.DurumId = durumId;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        var data = _context.Sikayets
            .Include(x => x.Kategori)
            .Include(x => x.Durum)
            .Include(x => x.Cevaps)
            .FirstOrDefault(x => x.SikayetId == id);

        ViewBag.Kategoriler = _context.Kategoris.ToList();

        return View(data);
    }

    [HttpPost]
    public IActionResult Update(Sikayet model)
    {
        var data = _context.Sikayets.Find(model.SikayetId);

        if (data != null)
        {
            data.Baslik = model.Baslik;
            data.Aciklama = model.Aciklama;
            data.Ilce = model.Ilce;
            data.KategoriId = model.KategoriId;
            data.DurumId = model.DurumId;

            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var data = _context.Sikayets
            .Include(x => x.Cevaps)
            .FirstOrDefault(x => x.SikayetId == id);

        if (data != null)
        {
            if (data.Cevaps != null)
                _context.Cevaps.RemoveRange(data.Cevaps);

            _context.Sikayets.Remove(data);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var data = _context.Sikayets
            .Include(x => x.Cevaps)
            .FirstOrDefault(x => x.SikayetId == id);

        if (data != null)
        {
            if (data.Cevaps != null)
                _context.Cevaps.RemoveRange(data.Cevaps);

            _context.Sikayets.Remove(data);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }


    public IActionResult ExportPdf()
    {
        var data = _context.Sikayets
            .Include(x => x.Kategori)
            .Include(x => x.Durum)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header()
                    .Text("Şikayet Raporu")
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
                        c.RelativeColumn();
                    });

                    table.Header(h =>
                    {
                        h.Cell().Text("Başlık").Bold();
                        h.Cell().Text("İlçe").Bold();
                        h.Cell().Text("Ad Soyad").Bold();
                        h.Cell().Text("Telefon").Bold();
                        h.Cell().Text("Kategori").Bold();
                        h.Cell().Text("Durum").Bold();
                        h.Cell().Text("Tarih").Bold();
                    });

                    foreach (var item in data)
                    {
                        table.Cell().Text(item.Baslik ?? "-");
                        table.Cell().Text(item.Ilce ?? "-");
                        table.Cell().Text(item.AdSoyad ?? "-");
                        table.Cell().Text(item.Telefon ?? "-");
                        table.Cell().Text(item.Kategori?.Ad ?? "-");
                        table.Cell().Text(item.Durum?.Ad ?? "-");
                        table.Cell().Text(item.CreatedDate.ToString("dd.MM.yyyy"));
                    }
                });
            });
        });

        return File(doc.GeneratePdf(), "application/pdf", "sikayetler.pdf");
    }

    public IActionResult ExportExcel()
    {
        var data = _context.Sikayets
            .Include(x => x.Kategori)
            .Include(x => x.Durum)
            .OrderByDescending(x => x.CreatedDate)
            .ToList();

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Şikayetler");

        sheet.Cells[1, 1].Value = "Başlık";
        sheet.Cells[1, 2].Value = "İlçe";
        sheet.Cells[1, 3].Value = "Ad Soyad";
        sheet.Cells[1, 4].Value = "Telefon";
        sheet.Cells[1, 5].Value = "Email";
        sheet.Cells[1, 6].Value = "Kategori";
        sheet.Cells[1, 7].Value = "Durum";
        sheet.Cells[1, 8].Value = "Açıklama";
        sheet.Cells[1, 9].Value = "Tarih";

        int row = 2;

        foreach (var item in data)
        {
            sheet.Cells[row, 1].Value = item.Baslik;
            sheet.Cells[row, 2].Value = item.Ilce;
            sheet.Cells[row, 3].Value = item.AdSoyad;
            sheet.Cells[row, 4].Value = item.Telefon;
            sheet.Cells[row, 5].Value = item.Email;
            sheet.Cells[row, 6].Value = item.Kategori?.Ad;
            sheet.Cells[row, 7].Value = item.Durum?.Ad;
            sheet.Cells[row, 8].Value = item.Aciklama;
            sheet.Cells[row, 9].Value = item.CreatedDate.ToString("dd.MM.yyyy HH:mm");
            row++;
        }

        sheet.Cells.AutoFitColumns();

        return File(
            package.GetAsByteArray(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "sikayetler.xlsx"
        );
    }
}