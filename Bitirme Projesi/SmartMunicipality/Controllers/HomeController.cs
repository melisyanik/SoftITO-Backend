using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using SmartMunicipality.Models;

namespace SmartMunicipality.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeDashboardViewModel();
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("http://localhost:5010/api/Dashboard/stats");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    model = System.Text.Json.JsonSerializer.Deserialize<HomeDashboardViewModel>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new HomeDashboardViewModel();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "API connection failed while fetching dashboard stats.");
                ViewBag.ErrorMessage = "API bağlantısı kurulamadı. Lütfen tüm API servislerinin (EFCoreApi, DapperApi) çalıştığından emin olun.";
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
