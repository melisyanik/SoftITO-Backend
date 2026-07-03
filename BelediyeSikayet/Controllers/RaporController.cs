using BelediyeSikayet.Models;
using BelediyeSikayet.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


using Microsoft.AspNetCore.Authorization;

[Authorize]
public class RaporController : Controller
{
    private readonly AppDbContext dbContext;

    public RaporController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IActionResult Index(int raporId = 1)
    {
        ViewBag.RaporId = raporId;

        ViewBag.Data = raporId switch
        {
            1 => Cevaplanmamis(),
            2 => IlceSayisi(),
            3 => KategoriSayisi(),
            4 => DurumSayisi(),
            5 => EnCokCevaplananIlce(),
            _ => Cevaplanmamis()
        };

        ViewBag.IlceChart = dbContext.Sikayets
    .GroupBy(x => x.Ilce)
    .Select(x => new RaporViewModel
    {
        AdSoyad = x.Key,
        Sayi = x.Count()
    })
    .ToList();

        ViewBag.DurumChart = dbContext.Sikayets
            .Include(x => x.Durum)
            .GroupBy(x => x.Durum.Ad)
            .Select(x => new RaporViewModel
            {
                AdSoyad = x.Key,
                Sayi = x.Count()
            })
            .ToList();

        return View();
    }
    public IActionResult ExportPdf(int raporId)
    {
        var data = GetRaporData(raporId);

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
                    });

                    table.Header(h =>
                    {
                        h.Cell().Text("Bilgi");
                        h.Cell().Text("Detay");
                        h.Cell().Text("Sayı");
                        h.Cell().Text("Tarih");
                    });

                    foreach (var item in data)
                    {
                        table.Cell().Text(item.AdSoyad ?? item.Baslik ?? "-");
                        table.Cell().Text(item.Ilce ?? item.KategoriAdi ?? "-");
                        table.Cell().Text(item.Sayi.ToString());
                        table.Cell().Text(item.Tarih?.ToString("dd.MM.yyyy") ?? "-");
                    }
                });
            });
        });

        var pdf = doc.GeneratePdf();
        return File(pdf, "application/pdf", $"rapor_{raporId}.pdf");
    }

    public IActionResult ExportExcel(int raporId)
    {
        var data = GetRaporData(raporId);

        using var package = new ExcelPackage();
        var sheet = package.Workbook.Worksheets.Add("Rapor");

        sheet.Cells[1, 1].Value = "Bilgi";
        sheet.Cells[1, 2].Value = "Detay";
        sheet.Cells[1, 3].Value = "Sayı";
        sheet.Cells[1, 4].Value = "Tarih";

        int row = 2;

        foreach (var item in data)
        {
            sheet.Cells[row, 1].Value = item.AdSoyad ?? item.Baslik ?? "-";
            sheet.Cells[row, 2].Value = item.Ilce ?? item.KategoriAdi ?? "-";
            sheet.Cells[row, 3].Value = item.Sayi;
            sheet.Cells[row, 4].Value = item.Tarih?.ToString("dd.MM.yyyy") ?? "-";
            row++;
        }

        sheet.Cells.AutoFitColumns();

        var stream = new MemoryStream(package.GetAsByteArray());

        return File(stream,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"rapor_{raporId}.xlsx");
    }

    private List<RaporViewModel> GetRaporData(int raporId)
    {
        return raporId switch
        {
            1 => Cevaplanmamis(),
            2 => IlceSayisi(),
            3 => KategoriSayisi(),
            4 => DurumSayisi(),
            5 => EnCokCevaplananIlce(),
            _ => Cevaplanmamis()
        };
    }

    public List<RaporViewModel> Cevaplanmamis()
    {
        return (
            from s in dbContext.Sikayets
            join k in dbContext.Kategoris on s.KategoriId equals k.KategoriId
            join d in dbContext.Durums on s.DurumId equals d.DurumId
            where !dbContext.Cevaps.Any(x => x.SikayetId == s.SikayetId)
            select new RaporViewModel
            {
                Baslik = s.Baslik,
                Ilce = s.Ilce,
                KategoriAdi = k.Ad,
                DurumAdi = d.Ad,
                Tarih = s.CreatedDate
            }
        ).ToList();
    }

    public List<RaporViewModel> IlceSayisi()
    {
        return dbContext.Sikayets
            .GroupBy(x => x.Ilce)
            .Select(x => new RaporViewModel
            {
                AdSoyad = x.Key,
                Sayi = x.Count()
            })
            .ToList();
    }

    public List<RaporViewModel> KategoriSayisi()
    {
        return (
            from s in dbContext.Sikayets
            join k in dbContext.Kategoris on s.KategoriId equals k.KategoriId
            group k by k.Ad into g
            select new RaporViewModel
            {
                AdSoyad = g.Key,
                Sayi = g.Count()
            }
        ).ToList();
    }

    public List<RaporViewModel> DurumSayisi()
    {
        return (
            from s in dbContext.Sikayets
            join d in dbContext.Durums on s.DurumId equals d.DurumId
            group d by d.Ad into g
            select new RaporViewModel
            {
                AdSoyad = g.Key,
                Sayi = g.Count()
            }
        ).ToList();
    }

    public List<RaporViewModel> EnCokCevaplananIlce()
    {
        return (
            from c in dbContext.Cevaps
            join s in dbContext.Sikayets on c.SikayetId equals s.SikayetId
            group s by s.Ilce into g
            select new RaporViewModel
            {
                AdSoyad = g.Key,
                Sayi = g.Count()
            }
        ).ToList();
    }
}