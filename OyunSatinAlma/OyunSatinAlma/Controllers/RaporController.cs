using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OyunSatinAlma.DATA.Data;
using OyunSatinAlma.MODEL.ViewModel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace OyunSatinAlma.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class RaporController : Controller
    {
        private readonly ApplicationDBContext db;

        public RaporController(ApplicationDBContext context)
        {
            db = context;
        }


        public IActionResult Index()
        {
            var oyunSatis = db.Siparisler
                .Include(x => x.Oyun)
                .GroupBy(x => x.Oyun.OyunAdi)
                .Select(g => new
                {
                    OyunAdi = g.Key,
                    Satis = g.Count()
                })
                .ToList();

            var durumDagilim = db.Siparisler
                .GroupBy(x => x.Durum)
                .Select(g => new
                {
                    Durum = g.Key,
                    Sayi = g.Count()
                })
                .ToList();

            ViewBag.OyunAdlari = oyunSatis.Select(x => x.OyunAdi).ToList();
            ViewBag.OyunSatis = oyunSatis.Select(x => x.Satis).ToList();

            ViewBag.DurumAdlari = durumDagilim.Select(x => x.Durum).ToList();
            ViewBag.DurumSayilari = durumDagilim.Select(x => x.Sayi).ToList();

            return View();
        }

        public IActionResult SiparisRapor()
        {
            var data = (from s in db.Siparisler
                        join o in db.Oyunlar on s.OyunId equals o.OyunId
                        join m in db.Musteriler on s.MusteriId equals m.MusteriId
                        select new SiparisRapor
                        {
                            SiparisId = s.SiparisId,
                            OyunAdi = o.OyunAdi,
                            MusteriAdi = m.AdSoyad,
                            Durum = s.Durum
                        }).ToList();

            return View(data);
        }

        public IActionResult OyunRapor()
        {
            var data = (from o in db.Oyunlar
                        join s in db.Siparisler on o.OyunId equals s.OyunId
                        select new OyunRapor
                        {
                            OyunAdi = o.OyunAdi,
                            Fiyat = o.Fiyat
                        }).Distinct().ToList();

            return View(data);
        }

        public IActionResult MusteriRapor()
        {
            var data = (from m in db.Musteriler
                        join s in db.Siparisler on m.MusteriId equals s.MusteriId
                        select new MusteriRapor
                        {
                            MusteriAdi = m.AdSoyad,
                            SiparisSayisi = db.Siparisler.Count(x => x.MusteriId == m.MusteriId)
                        }).Distinct().ToList();

            return View(data);
        }

        public IActionResult SatisRapor()
        {
            var data = (from s in db.Siparisler
                        join o in db.Oyunlar on s.OyunId equals o.OyunId
                        group s by o.OyunAdi into g
                        select new OyunSatisGroup
                        {
                            OyunAdi = g.Key,
                            SatisSayisi = g.Count(),
                            ToplamGelir = g.Sum(x => x.Oyun.Fiyat)
                        }).ToList();

            return View(data);
        }

        public IActionResult SonSiparisler()
        {
            var data = (from s in db.Siparisler
                        join o in db.Oyunlar on s.OyunId equals o.OyunId
                        join m in db.Musteriler on s.MusteriId equals m.MusteriId
                        orderby s.SiparisId descending
                        select new SonSiparisRapor
                        {
                            SiparisId = s.SiparisId,
                            OyunAdi = o.OyunAdi,
                            Tarih = s.SiparisTarihi
                        })
                        .Take(10)
                        .ToList();

            return View(data);
        }

        private (string title, List<object> data) GetReportData(string rapor)
        {
            switch (rapor)
            {
                case "siparis":
                    return ("Sipariş Raporu",
                        db.Siparisler
                        .Include(x => x.Oyun)
                        .Include(x => x.Musteri)
                        .Select(x => new {
                            x.SiparisId,
                            x.Oyun.OyunAdi,
                            x.Musteri.AdSoyad,
                            x.Durum
                        }).ToList<object>());

                case "oyun":
                    return ("Oyun Raporu",
                        db.Oyunlar.Select(x => new {
                            x.OyunAdi,
                            x.Fiyat
                        }).ToList<object>());

                case "musteri":
                    return ("Müşteri Raporu",
                        db.Musteriler.Select(x => new {
                            x.AdSoyad,
                            x.Email,
                            x.Telefon
                        }).ToList<object>());

                case "satis":
                    return ("Satış Raporu",
                        db.Siparisler
                        .Include(x => x.Oyun)
                        .GroupBy(x => x.Oyun.OyunAdi)
                        .Select(g => new {
                            Oyun = g.Key,
                            Satis = g.Count(),
                            Gelir = g.Sum(x => x.Oyun.Fiyat)
                        }).ToList<object>());

                case "son":
                    return ("Son Siparişler",
                        db.Siparisler
                        .Include(x => x.Oyun)
                        .OrderByDescending(x => x.SiparisId)
                        .Take(10)
                        .Select(x => new {
                            x.SiparisId,
                            x.Oyun.OyunAdi,
                            x.SiparisTarihi
                        }).ToList<object>());
            }

            return ("Boş", new List<object>());
        }

        public IActionResult ExportPdf(string rapor)
        {
            var result = GetReportData(rapor);

            var title = result.title;
            var data = result.data;

            if (data == null || data.Count == 0)
                return Content("Rapor boş");

            var props = data.First().GetType().GetProperties();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text(title)
                        .FontSize(18)
                        .Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in props)
                                columns.RelativeColumn();
                        });

                      
                        foreach (var p in props)
                        {
                            table.Cell()
                                .Background("#333")
                                .Padding(5)
                                .Text(p.Name)
                                .FontColor("#fff")
                                .Bold();
                        }

                     
                        foreach (var item in data)
                        {
                            foreach (var p in props)
                            {
                                table.Cell()
                                    .BorderBottom(1)
                                    .Padding(5)
                                    .Text(p.GetValue(item)?.ToString() ?? "-");
                            }
                        }
                    });
                });
            }).GeneratePdf();

            return File(pdf, "application/pdf", $"{rapor}.pdf");
        }

        public IActionResult ExportExcel(string rapor)
        {
            var result = GetReportData(rapor);

            var title = result.title;
            var data = result.data;

            if (data == null || data.Count == 0)
                return Content("Rapor boş");

            ExcelPackage.License.SetNonCommercialPersonal("GameProject");

            using var package = new ExcelPackage();
            var ws = package.Workbook.Worksheets.Add(title);

            var props = data.First().GetType().GetProperties();

            for (int i = 0; i < props.Length; i++)
                ws.Cells[1, i + 1].Value = props[i].Name;

            for (int r = 0; r < data.Count; r++)
            {
                for (int c = 0; c < props.Length; c++)
                {
                    ws.Cells[r + 2, c + 1].Value =
                        props[c].GetValue(data[r])?.ToString() ?? "-";
                }
            }

            ws.Cells.AutoFitColumns();

            return File(package.GetAsByteArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"{rapor}.xlsx");
        }
      
    }
}