using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.Data;
using System.Security.Claims;
using System.Text;

namespace SmartMunicipality.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscriptionsController(IHttpClientFactory httpClientFactory)
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
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/User/{userId}");

            var subscriptions = new List<SmartMunicipality.MODEL.Subscription>();
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                subscriptions = System.Text.Json.JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.Subscription>>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.Subscription>();
            }

            return View(subscriptions);
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var subscription = System.Text.Json.JsonSerializer.Deserialize<SmartMunicipality.MODEL.Subscription>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (subscription != null && subscription.UserId == userId)
                {
                    return View(subscription);
                }
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Pay(int billId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/Bill/{billId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var bill = System.Text.Json.JsonSerializer.Deserialize<SmartMunicipality.MODEL.Bill>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
                if (bill != null && bill.Subscription != null && bill.Subscription.UserId == userId && bill.Status != "Ödendi")
                {
                    return View(bill);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Pay(int billId, string paymentMethod)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5010/api/Subscriptions/Bill/{billId}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var bill = System.Text.Json.JsonSerializer.Deserialize<SmartMunicipality.MODEL.Bill>(jsonString, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (bill == null) return NotFound();

            
            var paymentPayload = new {
                BillId = billId,
                Amount = bill.Amount,
                PaymentMethod = paymentMethod ?? "Kredi Kartı"
            };

            var postJson = System.Text.Json.JsonSerializer.Serialize(paymentPayload);
            var content = new StringContent(postJson, Encoding.UTF8, "application/json");

            var payResponse = await client.PostAsync("http://localhost:5010/api/Payment", content);

            if (payResponse.IsSuccessStatusCode)
            {
                TempData["Message"] = "Ödemeniz başarıyla alınmıştır. Faturanız kapatıldı.";
                return RedirectToAction("Details", new { id = bill.SubscriptionId });
            }

            ModelState.AddModelError(string.Empty, "Ödeme işlemi gerçekleştirilemedi. Kart bilgilerinizi kontrol edin.");
            return View(bill);
        }
    }
}
