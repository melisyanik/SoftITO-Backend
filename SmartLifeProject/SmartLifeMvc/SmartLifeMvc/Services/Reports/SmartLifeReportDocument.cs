using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SmartLifeMvc.Models;
using SmartLifeMvc.ViewModels.Api;

namespace SmartLifeMvc.Services.Reports
{
    public class SmartLifeReportDocument : IDocument
    {
        private static readonly Color Purple = Color.FromHex("#7C5CFF");
        private static readonly Color LightGray = Color.FromHex("#F3F4FF");
        private static readonly Color Gray = Color.FromHex("#808080");

        private readonly List<Goal> _goals;
        private readonly List<TaskDto> _tasks;
        private readonly List<NoteDto> _notes;
        private readonly List<QuoteDto> _quotes;

        public SmartLifeReportDocument(
            List<Goal> goals,
            List<TaskDto> tasks,
            List<NoteDto> notes,
            List<QuoteDto> quotes)
        {
            _goals = goals;
            _tasks = tasks;
            _notes = notes;
            _quotes = quotes;
        }

        public DocumentMetadata GetMetadata()
        {
            var metadata = DocumentMetadata.Default;
            metadata.Title = "SmartLife Report";
            return metadata;
        }

        public DocumentSettings GetSettings() => DocumentSettings.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(30);
                page.Size(PageSizes.A4);
                page.DefaultTextStyle(x => x.FontSize(10));

                page.Header().Column(col =>
                {
                    col.Item().Text("SmartLife — Report").FontSize(22).Bold().FontColor(Purple);
                    col.Item().PaddingTop(2).Text($"Generated: {DateTime.Now:dd MMM yyyy HH:mm}")
                        .FontSize(10).FontColor(Gray);
                });

                page.Content().PaddingTop(16).Column(col =>
                {
                    col.Spacing(18);

                    AddSection(col, "Goals", new[] { "Title", "Started", "Progress", "Status" },
                        _goals.Select(g =>
                        {
                            var pct = g.GoalProgresses?.OrderByDescending(p => p.ProgressDate).FirstOrDefault()?.Percentage ?? 0;
                            var status = pct >= 100 ? "Done" : pct > 0 ? "In Progress" : "Active";
                            return new[] { g.Title, g.StartDate.ToShortDateString(), $"{pct}%", status };
                        }).ToList());

                    AddSection(col, "Tasks", new[] { "Title", "Priority", "Status", "Created" },
                        _tasks.Select(t => new[]
                        {
                            t.Title,
                            t.Priority ?? "-",
                            t.IsCompleted ? "Done" : "Active",
                            t.CreatedDate.ToShortDateString()
                        }).ToList());

                    AddSection(col, "Notes", new[] { "Title", "Content", "Created" },
                        _notes.Select(n => new[]
                        {
                            n.Title,
                            n.Content?.Length > 60 ? n.Content[..60] + "…" : n.Content ?? "",
                            n.CreatedDate.ToShortDateString()
                        }).ToList());

                    AddSection(col, "Quotes", new[] { "Quote", "Author", "Added" },
                        _quotes.Select(q => new[]
                        {
                            q.Text?.Length > 60 ? q.Text[..60] + "…" : q.Text ?? "",
                            q.Author ?? "",
                            q.CreatedDate.ToShortDateString()
                        }).ToList());
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ").FontSize(9).FontColor(Gray);
                    x.CurrentPageNumber().FontSize(9).FontColor(Gray);
                    x.Span(" / ").FontSize(9).FontColor(Gray);
                    x.TotalPages().FontSize(9).FontColor(Gray);
                });
            });
        }

        private static void AddSection(ColumnDescriptor column, string title, string[] headers, List<string[]> rows)
        {
            column.Item().Text(title).FontSize(14).Bold().FontColor(Purple);

            if (rows.Count == 0)
            {
                column.Item().Text("No data.").FontSize(10).FontColor(Gray);
                return;
            }

            column.Item().Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    foreach (var _ in headers)
                        columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    foreach (var h in headers)
                    {
                        header.Cell()
                            .Background(Purple)
                            .Padding(6)
                            .Text(h)
                            .FontSize(10).Bold().FontColor(Colors.White);
                    }
                });

                var alt = false;
                foreach (var row in rows)
                {
                    foreach (var cell in row)
                    {
                        table.Cell()
                            .Background(alt ? LightGray : Colors.White)
                            .Padding(5)
                            .Text(cell ?? "")
                            .FontSize(9);
                    }
                    alt = !alt;
                }
            });
        }
    }
}
