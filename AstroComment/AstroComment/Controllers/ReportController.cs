using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AstroComment.Data;
using AstroComment.Models;
using AstroComment.ViewModels;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AstroComment.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index(string searchField = null, string searchValue = null)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var model = new ReportViewModel();

            model.MostCommentedZodiacs = Context.Query<MostCommentedZodiacVM>("sp_MostCommentedZodiac").ToList();

            model.TodayHoroscopeStats = Context.Query<TodayHoroscopeStatsVM>("sp_TodayHoroscopeStats").ToList();

            model.AdminReplyRate = Context.Query<AdminReplyRateVM>("sp_AdminReplyRate").FirstOrDefault() 
                                   ?? new AdminReplyRateVM { TotalComments = 0, TotalReplies = 0, ReplyRate = 0 };

            model.DailyActivity = Context.Query<DailyActivityVM>("sp_DailyActivity").ToList();

            model.MostActiveUsers = Context.Query<MostActiveUsersVM>("sp_MostActiveUsers").ToList();

            model.SearchField = searchField;
            model.SearchValue = searchValue;
            if (!string.IsNullOrEmpty(searchField) && !string.IsNullOrEmpty(searchValue))
            {
                var param = new DynamicParameters();
                param.Add("@Field", searchField);
                param.Add("@Value", searchValue);
                model.SearchResults = Context.Query<UserModel>("sp_UserSearch", param).ToList();
            }
            else
            {
                model.SearchResults = Context.Query<UserModel>("sp_GetAllUsers").ToList();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ChangeRole(int userId, string role)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@Role", role);

            Context.Execute("SET QUOTED_IDENTIFIER ON; UPDATE Users SET Role = @Role WHERE UserId = @UserId", param, System.Data.CommandType.Text);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var param = new DynamicParameters();
            param.Add("@UserId", userId);

            Context.Execute(@"
                SET QUOTED_IDENTIFIER ON;
                DELETE FROM AdminReplies WHERE AdminId = @UserId;
                DELETE FROM AdminReplies WHERE CommentId IN (SELECT CommentId FROM Comments WHERE UserId = @UserId);
                DELETE FROM Comments WHERE UserId = @UserId;
                DELETE FROM Users WHERE UserId = @UserId;
            ", param, System.Data.CommandType.Text);

            return RedirectToAction("Index");
        }

        public IActionResult ExportExcel()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var mostCommented = Context.Query<MostCommentedZodiacVM>("sp_MostCommentedZodiac").ToList();
            var todayStats = Context.Query<TodayHoroscopeStatsVM>("sp_TodayHoroscopeStats").ToList();
            var replyRate = Context.Query<AdminReplyRateVM>("sp_AdminReplyRate").FirstOrDefault() 
                                   ?? new AdminReplyRateVM { TotalComments = 0, TotalReplies = 0, ReplyRate = 0 };
            var activeUsers = Context.Query<MostActiveUsersVM>("sp_MostActiveUsers").ToList();
            var dailyActivity = Context.Query<DailyActivityVM>("sp_DailyActivity").ToList();
            var users = Context.Query<UserModel>("sp_GetAllUsers").ToList();

            ExcelPackage.License.SetNonCommercialOrganization("AstroComment");
            using (var package = new ExcelPackage())
            {
                var wsStats = package.Workbook.Worksheets.Add("Genel İstatistikler");
                
                wsStats.Cells[1, 1].Value = "AstroComment Genel Sistem İstatistikleri";
                wsStats.Cells[1, 1].Style.Font.Bold = true;
                wsStats.Cells[1, 1].Style.Font.Size = 16;
                wsStats.Cells[2, 1].Value = "Raporlama Tarihi: " + DateTime.Now.ToString("g");
                wsStats.Cells[2, 1].Style.Font.Italic = true;

                wsStats.Cells[4, 1].Value = "Metrik";
                wsStats.Cells[4, 2].Value = "Değer";
                wsStats.Cells[4, 1, 4, 2].Style.Font.Bold = true;

                wsStats.Cells[5, 1].Value = "Toplam Yorum";
                wsStats.Cells[5, 2].Value = replyRate.TotalComments;
                wsStats.Cells[6, 1].Value = "Toplam Admin Cevabı";
                wsStats.Cells[6, 2].Value = replyRate.TotalReplies;
                wsStats.Cells[7, 1].Value = "Admin Yanıtlama Oranı";
                wsStats.Cells[7, 2].Value = "%" + replyRate.ReplyRate;

                wsStats.Cells[9, 1].Value = "En Çok Yorumlanan Burçlar";
                wsStats.Cells[9, 1].Style.Font.Bold = true;
                wsStats.Cells[10, 1].Value = "Burç Adı";
                wsStats.Cells[10, 2].Value = "Yorum Sayısı";
                wsStats.Cells[10, 1, 10, 2].Style.Font.Bold = true;

                int row = 11;
                foreach (var z in mostCommented)
                {
                    wsStats.Cells[row, 1].Value = z.Name;
                    wsStats.Cells[row, 2].Value = z.TotalComments;
                    row++;
                }

                row += 2;
                wsStats.Cells[row, 1].Value = "Bugünün Burç Yorum Aktivitesi";
                wsStats.Cells[row, 1].Style.Font.Bold = true;
                row++;
                wsStats.Cells[row, 1].Value = "Burç Adı";
                wsStats.Cells[row, 2].Value = "Bugünkü Yorum Sayısı";
                wsStats.Cells[row, 1, row, 2].Style.Font.Bold = true;
                row++;

                foreach (var ts in todayStats)
                {
                    wsStats.Cells[row, 1].Value = ts.Name;
                    wsStats.Cells[row, 2].Value = ts.TodayComments;
                    row++;
                }

                wsStats.Column(1).AutoFit();
                wsStats.Column(2).AutoFit();

                var wsUsers = package.Workbook.Worksheets.Add("Sistem Üyeleri");
                wsUsers.Cells[1, 1].Value = "Kullanıcı Adı";
                wsUsers.Cells[1, 2].Value = "E-posta";
                wsUsers.Cells[1, 3].Value = "Doğum Tarihi";
                wsUsers.Cells[1, 4].Value = "Rol";
                wsUsers.Cells[1, 5].Value = "Kayıt Tarihi";
                wsUsers.Cells[1, 1, 1, 5].Style.Font.Bold = true;

                row = 2;
                foreach (var u in users)
                {
                    wsUsers.Cells[row, 1].Value = u.Username;
                    wsUsers.Cells[row, 2].Value = u.Email;
                    wsUsers.Cells[row, 3].Value = u.BirthDate.ToShortDateString();
                    wsUsers.Cells[row, 4].Value = u.Role;
                    wsUsers.Cells[row, 5].Value = u.CreatedDate.ToString("g");
                    row++;
                }
                wsUsers.Column(1).AutoFit();
                wsUsers.Column(2).AutoFit();
                wsUsers.Column(3).AutoFit();
                wsUsers.Column(4).AutoFit();
                wsUsers.Column(5).AutoFit();

                var wsActivity = package.Workbook.Worksheets.Add("Günlük Aktivite");
                wsActivity.Cells[1, 1].Value = "Tarih";
                wsActivity.Cells[1, 2].Value = "Yorum Sayısı";
                wsActivity.Cells[1, 1, 1, 2].Style.Font.Bold = true;

                row = 2;
                foreach (var da in dailyActivity)
                {
                    wsActivity.Cells[row, 1].Value = da.Date.ToShortDateString();
                    wsActivity.Cells[row, 2].Value = da.TotalComments;
                    row++;
                }
                wsActivity.Column(1).AutoFit();
                wsActivity.Column(2).AutoFit();

                var fileBytes = package.GetAsByteArray();
                return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AstroComment_Sistem_Raporu.xlsx");
            }
        }

        public IActionResult ExportPdf()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
                return RedirectToAction("Login", "Auth");

            var mostCommented = Context.Query<MostCommentedZodiacVM>("sp_MostCommentedZodiac").ToList();
            var todayStats = Context.Query<TodayHoroscopeStatsVM>("sp_TodayHoroscopeStats").ToList();
            var replyRate = Context.Query<AdminReplyRateVM>("sp_AdminReplyRate").FirstOrDefault() 
                                   ?? new AdminReplyRateVM { TotalComments = 0, TotalReplies = 0, ReplyRate = 0 };
            var activeUsers = Context.Query<MostActiveUsersVM>("sp_MostActiveUsers").ToList();
            var dailyActivity = Context.Query<DailyActivityVM>("sp_DailyActivity").ToList();

            QuestPDF.Settings.License = LicenseType.Community;

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Arial"));

                    page.Header()
                        .Column(col =>
                        {
                            col.Item().Text("AstroComment Sistem Raporu").SemiBold().FontSize(22).FontColor(Colors.Purple.Medium);
                            col.Item().Text($"Oluşturulma Tarihi: {DateTime.Now:g}").FontSize(10).FontColor(Colors.Grey.Medium);
                            col.Item().PaddingVertical(5).LineHorizontal(1);
                        });

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(15);

                            column.Item().Text("Genel İstatistikler").Bold().FontSize(14).FontColor(Colors.Purple.Darken2);
                            
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Purple.Lighten5).Padding(5).Text("Metrik").Bold();
                                    header.Cell().Background(Colors.Purple.Lighten5).Padding(5).Text("Değer").Bold();
                                    header.Cell().Background(Colors.Purple.Lighten5).Padding(5).Text("Açıklama").Bold();
                                });

                                table.Cell().Padding(5).Text("Toplam Yorum");
                                table.Cell().Padding(5).Text(replyRate.TotalComments.ToString());
                                table.Cell().Padding(5).Text("Kullanıcı yorumu");

                                table.Cell().Padding(5).Text("Toplam Cevap");
                                table.Cell().Padding(5).Text(replyRate.TotalReplies.ToString());
                                table.Cell().Padding(5).Text("Admin yanıtı");

                                table.Cell().Padding(5).Text("Cevaplama Oranı");
                                table.Cell().Padding(5).Text($"%{replyRate.ReplyRate}");
                                table.Cell().Padding(5).Text("Yüzdesel oran");
                            });

                            column.Item().PaddingVertical(10);

                            column.Item().Text("En Çok Yorumlanan Burçlar").Bold().FontSize(14).FontColor(Colors.Purple.Darken2);
                            
                            column.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Burç Adı").Bold();
                                    header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Toplam Yorum").Bold();
                                });

                                foreach (var z in mostCommented)
                                {
                                    table.Cell().Padding(5).Text(z.Name);
                                    table.Cell().Padding(5).Text(z.TotalComments.ToString());
                                }
                            });

                            column.Item().PaddingVertical(10);

                            column.Item().Text("Bugünün Burç Yorum Aktivitesi").Bold().FontSize(14).FontColor(Colors.Purple.Darken2);

                            if (todayStats.Any())
                            {
                                column.Item().Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Burç Adı").Bold();
                                        header.Cell().Background(Colors.Grey.Lighten3).Padding(5).Text("Bugünkü Yorum").Bold();
                                    });

                                    foreach (var ts in todayStats)
                                    {
                                        table.Cell().Padding(5).Text(ts.Name);
                                        table.Cell().Padding(5).Text(ts.TodayComments.ToString());
                                    }
                                });
                            }
                            else
                            {
                                column.Item().Text("Bugün henüz yorum yapılmadı.").FontColor(Colors.Grey.Medium).Italic();
                            }
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Sayfa ").FontSize(9).FontColor(Colors.Grey.Medium);
                            x.CurrentPageNumber().FontSize(9).FontColor(Colors.Grey.Medium);
                        });
                });
            });

            using (var stream = new MemoryStream())
            {
                document.GeneratePdf(stream);
                return File(stream.ToArray(), "application/pdf", "AstroComment_Sistem_Raporu.pdf");
            }
        }
    }
}
