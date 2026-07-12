using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "http://localhost:5010/api/Notifications";

        public NotificationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/User/{userId}");

            var notifications = new List<Notification>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                notifications = JsonSerializer.Deserialize<List<Notification>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Notification>();
                
                
                foreach (var notif in notifications.Where(n => !n.IsRead))
                {
                    await client.PutAsync($"{_apiUrl}/{notif.Id}/Read", null);
                }
            }

            return View(notifications);
        }
    }
}
