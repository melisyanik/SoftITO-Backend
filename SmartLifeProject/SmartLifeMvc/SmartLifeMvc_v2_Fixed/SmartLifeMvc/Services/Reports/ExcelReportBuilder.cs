using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartLifeMvc.Models;
using SmartLifeMvc.ViewModels.Api;

namespace SmartLifeMvc.Services.Reports
{
    public static class ExcelReportBuilder
    {
        private static readonly Color HeaderColor = ColorTranslator.FromHtml("#7C5CFF");

        public static byte[] Build(
            List<Goal> goals,
            List<TaskDto> tasks,
            List<NoteDto> notes,
            List<QuoteDto> quotes)
        {
            using var package = new ExcelPackage();

            BuildGoalsSheet(package, goals);
            BuildTasksSheet(package, tasks);
            BuildNotesSheet(package, notes);
            BuildQuotesSheet(package, quotes);

            return package.GetAsByteArray();
        }

        private static void StyleHeaderRow(ExcelRange range)
        {
            range.Style.Font.Bold = true;
            range.Style.Font.Color.SetColor(Color.White);
            range.Style.Fill.PatternType = ExcelFillStyle.Solid;
            range.Style.Fill.BackgroundColor.SetColor(HeaderColor);
        }

        private static void BuildGoalsSheet(ExcelPackage package, List<Goal> goals)
        {
            var ws = package.Workbook.Worksheets.Add("Goals");

            ws.Cells[1, 1].Value = "Title";
            ws.Cells[1, 2].Value = "Description";
            ws.Cells[1, 3].Value = "Started";
            ws.Cells[1, 4].Value = "Progress %";
            ws.Cells[1, 5].Value = "Status";
            StyleHeaderRow(ws.Cells[1, 1, 1, 5]);

            for (int i = 0; i < goals.Count; i++)
            {
                var g = goals[i];
                var pct = g.GoalProgresses?.OrderByDescending(p => p.ProgressDate).FirstOrDefault()?.Percentage ?? 0;
                var status = pct >= 100 ? "Done" : pct > 0 ? "In Progress" : "Active";
                var row = i + 2;

                ws.Cells[row, 1].Value = g.Title;
                ws.Cells[row, 2].Value = g.Description;
                ws.Cells[row, 3].Value = g.StartDate.ToShortDateString();
                ws.Cells[row, 4].Value = pct;
                ws.Cells[row, 5].Value = status;
            }

            ws.Cells[ws.Dimension?.Address ?? "A1"].AutoFitColumns();
        }

        private static void BuildTasksSheet(ExcelPackage package, List<TaskDto> tasks)
        {
            var ws = package.Workbook.Worksheets.Add("Tasks");

            ws.Cells[1, 1].Value = "Title";
            ws.Cells[1, 2].Value = "Priority";
            ws.Cells[1, 3].Value = "Status";
            ws.Cells[1, 4].Value = "Created";
            StyleHeaderRow(ws.Cells[1, 1, 1, 4]);

            for (int i = 0; i < tasks.Count; i++)
            {
                var t = tasks[i];
                var row = i + 2;

                ws.Cells[row, 1].Value = t.Title;
                ws.Cells[row, 2].Value = t.Priority;
                ws.Cells[row, 3].Value = t.IsCompleted ? "Done" : "Active";
                ws.Cells[row, 4].Value = t.CreatedDate.ToShortDateString();
            }

            ws.Cells[ws.Dimension?.Address ?? "A1"].AutoFitColumns();
        }

        private static void BuildNotesSheet(ExcelPackage package, List<NoteDto> notes)
        {
            var ws = package.Workbook.Worksheets.Add("Notes");

            ws.Cells[1, 1].Value = "Title";
            ws.Cells[1, 2].Value = "Content";
            ws.Cells[1, 3].Value = "Created";
            StyleHeaderRow(ws.Cells[1, 1, 1, 3]);

            for (int i = 0; i < notes.Count; i++)
            {
                var row = i + 2;
                ws.Cells[row, 1].Value = notes[i].Title;
                ws.Cells[row, 2].Value = notes[i].Content;
                ws.Cells[row, 3].Value = notes[i].CreatedDate.ToShortDateString();
            }

            ws.Cells[ws.Dimension?.Address ?? "A1"].AutoFitColumns();
        }

        private static void BuildQuotesSheet(ExcelPackage package, List<QuoteDto> quotes)
        {
            var ws = package.Workbook.Worksheets.Add("Quotes");

            ws.Cells[1, 1].Value = "Quote";
            ws.Cells[1, 2].Value = "Author";
            ws.Cells[1, 3].Value = "Added";
            StyleHeaderRow(ws.Cells[1, 1, 1, 3]);

            for (int i = 0; i < quotes.Count; i++)
            {
                var row = i + 2;
                ws.Cells[row, 1].Value = quotes[i].Text;
                ws.Cells[row, 2].Value = quotes[i].Author;
                ws.Cells[row, 3].Value = quotes[i].CreatedDate.ToShortDateString();
            }

            ws.Cells[ws.Dimension?.Address ?? "A1"].AutoFitColumns();
        }
    }
}
