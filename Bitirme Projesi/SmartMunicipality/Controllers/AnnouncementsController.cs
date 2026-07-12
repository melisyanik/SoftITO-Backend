using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;

namespace SmartMunicipality.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AnnouncementsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5010/api/Announcements");

            var announcements = new List<SmartMunicipality.MODEL.Announcement>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                announcements = System.Text.Json.JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.Announcement>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.Announcement>();
            }

            return View(announcements);
        }
    }
}
