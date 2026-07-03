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
    public class SiparisController : Controller
    {
        private readonly ApplicationDBContext db;

        public SiparisController(ApplicationDBContext context)
        {
            db = context;
        }
        public IActionResult Index(string searchType, string search)
        {
            var siparisler = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .ToList();

            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();

                if (searchType == "oyun")
                {
                    siparisler = siparisler
                        .Where(x => x.Oyun.OyunAdi.ToLower().Contains(search))
                        .ToList();
                }
                else if (searchType == "musteri")
                {
                    siparisler = siparisler
                        .Where(x => x.Musteri.AdSoyad.ToLower().Contains(search))
                        .ToList();
                }
                else if (searchType == "oyunId")
                {
                    if (int.TryParse(search, out int oyunId))
                    {
                        siparisler = siparisler
                            .Where(x => x.OyunId == oyunId)
                            .ToList();
                    }
                }
                else if (searchType == "musteriId")
                {
                    if (int.TryParse(search, out int musteriId))
                    {
                        siparisler = siparisler
                            .Where(x => x.MusteriId == musteriId)
                            .ToList();
                    }
                }
            }

            return View(siparisler);
        }

   
        public IActionResult Create()
        {
            ViewBag.Oyunlar = db.Oyunlar.ToList();
            ViewBag.Musteriler = db.Musteriler.ToList();
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Siparis s)
        {
            s.SiparisTarihi = DateTime.Now;
            s.Durum = "Beklemede";

            db.Siparisler.Add(s);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

   
        public IActionResult Update(int id)
        {
            var siparis = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .FirstOrDefault(x => x.SiparisId == id);

            return View(siparis);
        }

      
        [HttpPost]
        public IActionResult Update(Siparis s)
        {
            var siparis = db.Siparisler.Find(s.SiparisId);

            if (siparis != null)
            {
                siparis.OyunId = s.OyunId;
                siparis.MusteriId = s.MusteriId;
                siparis.Durum = s.Durum;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

     
        public IActionResult Delete(int id)
        {
            var siparis = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .FirstOrDefault(x => x.SiparisId == id);

            return View(siparis);
        }

      
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var siparis = db.Siparisler.Find(id);

            if (siparis != null)
            {
                db.Siparisler.Remove(siparis);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public IActionResult ChangeStatus(int id, string durum)
        {
            var siparis = db.Siparisler.Find(id);

            if (siparis != null)
            {
                siparis.Durum = durum;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var siparisler = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Sipariş Listesi")
                        .FontSize(20)
                        .Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.ConstantColumn(120);
                            columns.ConstantColumn(100);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").Bold();
                            header.Cell().Text("Müşteri").Bold();
                            header.Cell().Text("Oyun").Bold();
                            header.Cell().Text("Tarih").Bold();
                            header.Cell().Text("Durum").Bold();
                        });

                        foreach (var item in siparisler)
                        {
                            table.Cell().Text(item.SiparisId.ToString());
                            table.Cell().Text(item.Musteri?.AdSoyad ?? "");
                            table.Cell().Text(item.Oyun?.OyunAdi ?? "");
                            table.Cell().Text(item.SiparisTarihi.ToString("dd.MM.yyyy"));
                            table.Cell().Text(item.Durum ?? "");
                        }
                    });
                });
            });

            var bytes = pdf.GeneratePdf();

            return File(
                bytes,
                "application/pdf",
                "Siparisler.pdf");
        }

        public IActionResult ExportToExcel()
        {
            var siparisler = db.Siparisler
                .Include(x => x.Oyun)
                .Include(x => x.Musteri)
                .ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Siparisler");

                ws.Cells[1, 1].Value = "Sipariş ID";
                ws.Cells[1, 2].Value = "Müşteri ID";
                ws.Cells[1, 3].Value = "Müşteri";
                ws.Cells[1, 4].Value = "Oyun ID";
                ws.Cells[1, 5].Value = "Oyun";
                ws.Cells[1, 6].Value = "Sipariş Tarihi";
                ws.Cells[1, 7].Value = "Durum";

                int row = 2;

                foreach (var item in siparisler)
                {
                    ws.Cells[row, 1].Value = item.SiparisId;
                    ws.Cells[row, 2].Value = item.MusteriId;
                    ws.Cells[row, 3].Value = item.Musteri?.AdSoyad;
                    ws.Cells[row, 4].Value = item.OyunId;
                    ws.Cells[row, 5].Value = item.Oyun?.OyunAdi;
                    ws.Cells[row, 6].Value = item.SiparisTarihi.ToString("dd.MM.yyyy HH:mm");
                    ws.Cells[row, 7].Value = item.Durum;

                    row++;
                }

                ws.Cells.AutoFitColumns();

                var content = package.GetAsByteArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Siparisler.xlsx");
            }
        }
    }
}