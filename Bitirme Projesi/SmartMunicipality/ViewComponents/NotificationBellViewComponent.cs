using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using System.Security.Claims;

namespace SmartMunicipality.ViewComponents
{
    public class NotificationBellViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotificationBellViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = ((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier);
            var notifications = new List<SmartMunicipality.MODEL.Notification>();

            if (!string.IsNullOrEmpty(userId))
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"http://localhost:5010/api/Notifications/User/{userId}/Unread");

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    notifications = System.Text.Json.JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.Notification>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.Notification>();
                }
            }

            return View(notifications);
        }
    }
}
