using BelediyeSikayet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

using Microsoft.AspNetCore.Authorization;

[Authorize]
public class KategoriController : Controller
{
    private readonly AppDbContext _context;

    public KategoriController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string field, string value)
    {
        var query = _context.Kategoris.AsQueryable();

        if (!string.IsNullOrEmpty(field) && !string.IsNullOrEmpty(value))
        {
            if (field == "id")
            {
                if (int.TryParse(value, out int id))
                    query = query.Where(x => x.KategoriId == id);
            }

            if (field == "ad")
            {
                query = query.Where(x => x.Ad.Contains(value));
            }
        }

        ViewBag.Fields = new List<string>
    {
        "id",
        "ad"
    };

        return View(query.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Kategori model)
    {
        _context.Kategoris.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Update(int id)
    {
        return View(_context.Kategoris.Find(id));
    }

    [HttpPost]
    public IActionResult Update(Kategori model)
    {
        var data = _context.Kategoris.Find(model.KategoriId);

        if (data != null)
        {
            data.Ad = model.Ad;
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        return View(_context.Kategoris.Find(id));
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var data = _context.Kategoris.Find(id);

        if (data != null)
        {
            _context.Kategoris.Remove(data);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult ExportPdf()
    {
        var data = _context.Kategoris
            .Include(x => x.Sikayets)
            .ToList();

        var doc = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Margin(20);

                page.Header()
                    .Text("Kategori Raporu")
                    .FontSize(18).Bold();

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.RelativeColumn();
                        c.RelativeColumn(); 
                        c.RelativeColumn(); 
                    });

                    table.Header(h =>
                    {
                        h.Cell().Text("Kategori ID").Bold();
                        h.Cell().Text("Kategori Adı").Bold();
                        h.Cell().Text("Şikayet Sayısı").Bold();
                    });

                    foreach (var item in data)
                    {
                        table.Cell().Text(item.KategoriId.ToString());
                        table.Cell().Text(item.Ad ?? "-");
                        table.Cell().Text(item.Sikayets?.Count.ToString() ?? "0");
                    }
                });
            });
        });

        var pdf = doc.GeneratePdf();
        return File(pdf, "application/pdf", "kategoriler.pdf");
    }

    public IActionResult ExportExcel()
    {
        var data = _context.Kategoris
            .Include(x => x.Sikayets)
            .ToList();

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Kategoriler");

     
        sheet.Cells[1, 1].Value = "Kategori ID";
        sheet.Cells[1, 2].Value = "Kategori Adı";
        sheet.Cells[1, 3].Value = "Şikayet Sayısı";

        int row = 2;

        foreach (var item in data)
        {
            sheet.Cells[row, 1].Value = item.KategoriId;
            sheet.Cells[row, 2].Value = item.Ad;
            sheet.Cells[row, 3].Value = item.Sikayets?.Count ?? 0;

            row++;
        }

        sheet.Cells.AutoFitColumns();

        var stream = new MemoryStream(package.GetAsByteArray());

        return File(stream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "kategoriler.xlsx");
    }
}