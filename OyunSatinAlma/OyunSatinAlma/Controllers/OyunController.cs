using Microsoft.AspNetCore.Mvc;
using OyunSatinAlma.DATA.Data;
using OyunSatinAlma.MODEL;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace OyunSatinAlma.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class OyunController : Controller
    {
        private readonly ApplicationDBContext db;

        public OyunController(ApplicationDBContext context)
        {
            db = context;
        }

     
        public IActionResult Index(string searchType, string searchText)
        {
            var oyunlar = db.Oyunlar.ToList();

            if (!string.IsNullOrEmpty(searchText))
            {

                if (searchType == "id")
                {
                    oyunlar = oyunlar
                        .Where(x => x.OyunId.ToString() == searchText)
                        .ToList();
                }

              else if (searchType == "ad")
                {
                    oyunlar = oyunlar
                        .Where(x => x.OyunAdi.ToLower().Contains(searchText.ToLower()))
                        .ToList();
                }
               
            }

            return View(oyunlar);
        }

     
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Oyun o)
        {
            db.Oyunlar.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     
        public IActionResult Update(int id)
        {
            var oyun = db.Oyunlar.Find(id);
            return View(oyun);
        }

       
        [HttpPost]
        public IActionResult Update(Oyun o)
        {
            var oyun = db.Oyunlar.Find(o.OyunId);

            if (oyun != null)
            {
                oyun.OyunAdi = o.OyunAdi;
                oyun.Fiyat = o.Fiyat;
                oyun.ResimUrl = o.ResimUrl;

                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

      
        public IActionResult Delete(int id)
        {
            var oyun = db.Oyunlar.Find(id);
            return View(oyun);
        }

     
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var oyun = db.Oyunlar.Find(id);

            if (oyun != null)
            {
                db.Oyunlar.Remove(oyun);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult ExportToPdf()
        {
            var oyunlar = db.Oyunlar.ToList();

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(20);

                    page.Header()
                        .Text("Oyun Listesi")
                        .FontSize(20)
                        .Bold();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(60);
                            columns.RelativeColumn();
                            columns.ConstantColumn(100);
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("ID").Bold();
                            header.Cell().Text("Oyun Adı").Bold();
                            header.Cell().Text("Fiyat").Bold();
                        });

                        foreach (var item in oyunlar)
                        {
                            table.Cell().Text(item.OyunId.ToString());
                            table.Cell().Text(item.OyunAdi);
                            table.Cell().Text(item.Fiyat.ToString());
                        }
                    });
                });
            });

            var bytes = pdf.GeneratePdf();

            return File(
                bytes,
                "application/pdf",
                "Oyunlar.pdf");
        }
        public IActionResult ExportToExcel()
        {

            var oyunlar = db.Oyunlar.ToList();

            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("Oyunlar");

                ws.Cells[1, 1].Value = "ID";
                ws.Cells[1, 2].Value = "Oyun Adı";
                ws.Cells[1, 3].Value = "Fiyat";

                int row = 2;

                foreach (var item in oyunlar)
                {
                    ws.Cells[row, 1].Value = item.OyunId;
                    ws.Cells[row, 2].Value = item.OyunAdi;
                    ws.Cells[row, 3].Value = item.Fiyat;

                    row++;
                }

                ws.Cells.AutoFitColumns();

                var content = package.GetAsByteArray();

                return File(
                    content,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "Oyunlar.xlsx");
            }
        }
    }
}