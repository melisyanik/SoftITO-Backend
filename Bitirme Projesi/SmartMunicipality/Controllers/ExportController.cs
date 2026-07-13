using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using System.Security.Claims;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace SmartMunicipality.Controllers
{
    public class ExportController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> DownloadExcel(int billId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/Bill/{billId}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var bill = System.Text.Json.JsonSerializer.Deserialize<SmartMunicipality.MODEL.Bill>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (bill == null || bill.Subscription == null || bill.Subscription.UserId != userId) return NotFound();

            ExcelPackage.License.SetNonCommercialPersonal("SmartMunicipality");

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Fatura Detayı");

                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = "SMART MUNICIPALITY - FATURA BİLGİLERİ";
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.Font.Size = 14;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3"].Value = "Abone No:";
                worksheet.Cells["B3"].Value = bill.Subscription.SubscriberNo;

                worksheet.Cells["A4"].Value = "Fatura No:";
                worksheet.Cells["B4"].Value = bill.BillNo;

                worksheet.Cells["A5"].Value = "Hizmet Türü:";
                worksheet.Cells["B5"].Value = bill.Subscription.ServiceType?.Name;

                worksheet.Cells["A6"].Value = "Dönem:";
                worksheet.Cells["B6"].Value = $"{bill.BillMonth}/{bill.BillYear}";

                worksheet.Cells["A7"].Value = "Son Ödeme:";
                worksheet.Cells["B7"].Value = bill.DueDate.ToString("dd.MM.yyyy");

                worksheet.Cells["A8"].Value = "Tutar:";
                worksheet.Cells["B8"].Value = $"{bill.Amount} TL";

                worksheet.Cells["A9"].Value = "Durum:";
                worksheet.Cells["B9"].Value = bill.Status;

                worksheet.Cells["A3:A9"].Style.Font.Bold = true;
                worksheet.Cells.AutoFitColumns();

                var bytes = package.GetAsByteArray();
                string excelName = $"Fatura-{bill.BillNo}.xlsx";
                return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }

        public async Task<IActionResult> DownloadPdf(int billId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/Bill/{billId}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var bill = System.Text.Json.JsonSerializer.Deserialize<SmartMunicipality.MODEL.Bill>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (bill == null || bill.Subscription == null || bill.Subscription.UserId != userId) return NotFound();

            if (bill == null) return NotFound();

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("SMART MUNICIPALITY FATURA")
                        .SemiBold().FontSize(24).FontColor(Colors.Teal.Darken2);

                    page.Content().PaddingVertical(1, Unit.Centimetre).Column(x =>
                    {
                        x.Spacing(10);
                        x.Item().Text($"Sayın {bill.Subscription.User.Name} {bill.Subscription.User.Surname}");
                        x.Item().Text($"Adres: {bill.Subscription.Address}");
                        
                        x.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        x.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(1);
                                c.RelativeColumn(2);
                            });

                            t.Cell().Text("Hizmet Türü:");
                            t.Cell().Text(bill.Subscription.ServiceType.Name).SemiBold();

                            t.Cell().Text("Abone No:");
                            t.Cell().Text(bill.Subscription.SubscriberNo).SemiBold();

                            t.Cell().Text("Fatura No:");
                            t.Cell().Text(bill.BillNo).SemiBold();

                            t.Cell().Text("Dönem:");
                            t.Cell().Text($"{bill.BillMonth}/{bill.BillYear}").SemiBold();

                            t.Cell().Text("Son Ödeme:");
                            t.Cell().Text(bill.DueDate.ToString("dd.MM.yyyy")).SemiBold();

                            t.Cell().Text("Durum:");
                            t.Cell().Text(bill.Status).SemiBold().FontColor(bill.Status == "Ödendi" ? Colors.Green.Medium : Colors.Red.Medium);

                            t.Cell().Text("Tutar:");
                            t.Cell().Text($"{bill.Amount} TL").SemiBold().FontSize(14);
                        });
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Sayfa ");
                        x.CurrentPageNumber();
                        x.Span(" / ");
                        x.TotalPages();
                    });
                });
            });

            var pdfStream = new MemoryStream();
            document.GeneratePdf(pdfStream);
            pdfStream.Position = 0;

            return File(pdfStream, "application/pdf", $"Fatura-{bill.BillNo}.pdf");
        }
    }
}
