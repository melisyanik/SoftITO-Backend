using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QuestPDF.Fluent;
using SmartLifeMvc.Models;
using SmartLifeMvc.Services.Reports;
using SmartLifeMvc.ViewModels.Api;
using System.Security.Claims;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public ReportController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient Client => _httpClientFactory.CreateClient("SmartLifeApi");

        private async Task<(List<Goal> goals, List<TaskDto> tasks, List<NoteDto> notes, List<QuoteDto> quotes)> LoadAllData()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var goals = await _context.Goals
                .Where(g => g.UserId == userId)
                .Include(g => g.GoalProgresses)
                .ToListAsync();

            var tasksResp = await Client.GetAsync("Tasks/GetTasks");
            var tasks = JsonConvert.DeserializeObject<List<TaskDto>>(await tasksResp.Content.ReadAsStringAsync()) ?? new();

            var notesResp = await Client.GetAsync("Notes/GetNotes");
            var notes = JsonConvert.DeserializeObject<List<NoteDto>>(await notesResp.Content.ReadAsStringAsync()) ?? new();

            var quotesResp = await Client.GetAsync("Quotes/GetQuotes");
            var quotes = JsonConvert.DeserializeObject<List<QuoteDto>>(await quotesResp.Content.ReadAsStringAsync()) ?? new();

            return (goals, tasks, notes, quotes);
        }

        public async Task<IActionResult> Index()
        {
            var (goals, tasks, notes, quotes) = await LoadAllData();

            ViewBag.GoalStats = new
            {
                Total = goals.Count,
                Done = goals.Count(g => (g.GoalProgresses?.OrderByDescending(p => p.ProgressDate).FirstOrDefault()?.Percentage ?? 0) >= 100),
                InProgress = goals.Count(g => { var p = g.GoalProgresses?.OrderByDescending(x => x.ProgressDate).FirstOrDefault()?.Percentage ?? 0; return p > 0 && p < 100; }),
                Active = goals.Count(g => (g.GoalProgresses?.OrderByDescending(p => p.ProgressDate).FirstOrDefault()?.Percentage ?? 0) == 0),
            };

            ViewBag.TaskStats = new
            {
                Total = tasks.Count,
                Done = tasks.Count(t => t.IsCompleted),
                Active = tasks.Count(t => !t.IsCompleted),
                HighPriority = tasks.Count(t => t.Priority == "High"),
            };

            ViewBag.NoteCount = notes.Count;
            ViewBag.QuoteCount = quotes.Count;
            ViewBag.Goals = goals;
            ViewBag.Tasks = tasks;
            ViewBag.Notes = notes;
            ViewBag.Quotes = quotes;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ExportExcel()
        {
            var (goals, tasks, notes, quotes) = await LoadAllData();

            var bytes = ExcelReportBuilder.Build(goals, tasks, notes, quotes);

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"SmartLife_Report_{DateTime.Now:yyyyMMdd}.xlsx");
        }

        [HttpGet]
        public async Task<IActionResult> ExportPdf()
        {
            var (goals, tasks, notes, quotes) = await LoadAllData();

            var document = new SmartLifeReportDocument(goals, tasks, notes, quotes);
            var bytes = document.GeneratePdf();

            return File(bytes, "application/pdf", $"SmartLife_Report_{DateTime.Now:yyyyMMdd}.pdf");
        }
    }
}
