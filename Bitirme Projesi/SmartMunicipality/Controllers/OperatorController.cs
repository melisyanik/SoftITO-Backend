using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.MODEL;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SmartMunicipality.Controllers
{
    [Authorize(Roles = "Operator,Admin")]
    public class OperatorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "http://localhost:5010/api";

        public OperatorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Complaints()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Complaints");
            var complaints = new List<Complaint>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                complaints = JsonSerializer.Deserialize<List<Complaint>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Complaint>();
            }

            return View(complaints);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RespondComplaint(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Complaints/{id}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var complaint = JsonSerializer.Deserialize<Complaint>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(complaint);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RespondComplaint(int id, string responseText, int statusId)
        {
            var client = _httpClientFactory.CreateClient();

            
            var getResp = await client.GetAsync($"{_apiBaseUrl}/Complaints/{id}");
            if (!getResp.IsSuccessStatusCode) return NotFound();
            var compJson = await getResp.Content.ReadAsStringAsync();
            var complaint = JsonSerializer.Deserialize<Complaint>(compJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (complaint == null) return NotFound();

            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
            var responsePayload = new
            {
                ComplaintId = id,
                UserId = userId,
                ResponseText = responseText
            };
            var respJson = JsonSerializer.Serialize(responsePayload);
            var respContent = new StringContent(respJson, Encoding.UTF8, "application/json");
            await client.PostAsync($"{_apiBaseUrl}/Complaints/{id}/Respond", respContent);

            
            var updatePayload = new
            {
                Id = complaint.Id,
                Title = complaint.Title,
                Description = complaint.Description,
                Phone = complaint.Phone,
                Address = complaint.Address,
                Latitude = complaint.Latitude,
                Longitude = complaint.Longitude,
                CreatedDate = complaint.CreatedDate,
                CategoryId = complaint.CategoryId,
                StatusId = statusId,
                UserId = complaint.UserId
            };
            var updateJson = JsonSerializer.Serialize(updatePayload);
            var updateContent = new StringContent(updateJson, Encoding.UTF8, "application/json");
            var putResp = await client.PutAsync($"{_apiBaseUrl}/Complaints/{id}", updateContent);
            if (!putResp.IsSuccessStatusCode)
            {
                var errBody = await putResp.Content.ReadAsStringAsync();
                throw new Exception($"Failed to update complaint status in API. Status: {putResp.StatusCode}, Error: {errBody}");
            }

            
            try
            {
                var statusNames = new Dictionary<int, string> { { 1, "Beklemede" }, { 2, "İnceleniyor" }, { 3, "Çözüldü" }, { 4, "Reddedildi" } };
                string newStatus = statusNames.TryGetValue(statusId, out var name) ? name : "Güncellendi";

                var notification = new
                {
                    UserId = complaint.UserId,
                    Title = "Şikayetiniz Güncellendi",
                    Message = $"'{complaint.Title}' başlıklı şikayetinizin durumu '{newStatus}' olarak güncellenmiştir. Yanıt: {responseText}",
                    IsRead = false,
                    CreatedDate = DateTime.Now,
                    NotificationType = "Complaint"
                };
                var notifJson = JsonSerializer.Serialize(notification);
                var notifContent = new StringContent(notifJson, Encoding.UTF8, "application/json");
                await client.PostAsync($"{_apiBaseUrl}/Notifications", notifContent);
            }
            catch { }

            TempData["Message"] = "Şikayet başarıyla yanıtlandı ve durumu güncellendi.";
            return RedirectToAction("Complaints");
        }

        
        
        
        public async Task<IActionResult> Subscriptions()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Subscriptions");
            var subscriptions = new List<Subscription>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                subscriptions = JsonSerializer.Deserialize<List<Subscription>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Subscription>();
            }

            return View(subscriptions);
        }

        [HttpGet]
        public async Task<IActionResult> AddSubscription()
        {
            await PopulateCitizensViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription(Subscription sub)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCitizensViewBag();
                return View(sub);
            }

            sub.CreatedDate = DateTime.Now;
            sub.IsActive = true;

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(sub);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_apiBaseUrl}/Subscriptions", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Abonelik başarıyla oluşturuldu.";
                return RedirectToAction("Subscriptions");
            }

            await PopulateCitizensViewBag();
            ModelState.AddModelError(string.Empty, "Abonelik kaydedilirken bir hata oluştu.");
            return View(sub);
        }

        private async Task PopulateCitizensViewBag()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiBaseUrl}/User");
                var users = new List<CitizenUserViewModel>();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<List<CitizenUserViewModel>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CitizenUserViewModel>();
                }

                ViewBag.Citizens = users.Where(u => u.Role == "Citizen").ToList();
            }
            catch
            {
                ViewBag.Citizens = new List<CitizenUserViewModel>();
            }
        }

        public class CitizenUserViewModel
        {
            public string Id { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Surname { get; set; } = string.Empty;
            public string Role { get; set; } = string.Empty;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleSubscription(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Subscriptions/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var sub = JsonSerializer.Deserialize<Subscription>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (sub != null)
            {
                sub.IsActive = !sub.IsActive;
                
                sub.ServiceType = null!;
                sub.User = null!;
                sub.Bills = null!;
                sub.ConsumptionRecords = null!;
                var putJson = JsonSerializer.Serialize(sub);
                var content = new StringContent(putJson, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_apiBaseUrl}/Subscriptions/{id}", content);
            }

            return RedirectToAction("Subscriptions");
        }

        
        
        
        [HttpGet]
        public async Task<IActionResult> MeterReading(int? subscriptionId)
        {
            await PopulateSubscriptionsViewBag();

            
            if (subscriptionId.HasValue && subscriptionId.Value > 0)
            {
                ViewBag.SelectedSubscriptionId = subscriptionId.Value;
                var client = _httpClientFactory.CreateClient();
                var histResp = await client.GetAsync($"{_apiBaseUrl}/Consumption/Subscription/{subscriptionId.Value}");
                if (histResp.IsSuccessStatusCode)
                {
                    var histJson = await histResp.Content.ReadAsStringAsync();
                    ViewBag.ConsumptionHistory = JsonSerializer.Deserialize<List<ConsumptionRecord>>(histJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ConsumptionRecord>();
                }
            }
            else
            {
                ViewBag.SelectedSubscriptionId = 0;
                ViewBag.ConsumptionHistory = new List<ConsumptionRecord>();
            }

            return View();
        }

        private async Task PopulateSubscriptionsViewBag()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Subscriptions");
            var subscriptions = new List<Subscription>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                subscriptions = JsonSerializer.Deserialize<List<Subscription>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Subscription>();
            }

            ViewBag.Subscriptions = subscriptions.Where(s => s.IsActive).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> MeterReading(int subscriptionId, decimal consumptionValue, DateTime? recordDate)
        {
            if (subscriptionId <= 0 || consumptionValue < 0)
            {
                ModelState.AddModelError(string.Empty, "Lütfen geçerli değerler girin.");
                await PopulateSubscriptionsViewBag();
                ViewBag.SelectedSubscriptionId = subscriptionId;
                ViewBag.ConsumptionHistory = new List<ConsumptionRecord>();
                return View();
            }

            var client = _httpClientFactory.CreateClient();

            
            var histResp = await client.GetAsync($"{_apiBaseUrl}/Consumption/Subscription/{subscriptionId}");
            List<ConsumptionRecord> history = new List<ConsumptionRecord>();
            if (histResp.IsSuccessStatusCode)
            {
                var histJson = await histResp.Content.ReadAsStringAsync();
                history = JsonSerializer.Deserialize<List<ConsumptionRecord>>(histJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ConsumptionRecord>();
                var lastRecord = history.OrderByDescending(h => h.RecordDate).FirstOrDefault();
                if (lastRecord != null && consumptionValue < lastRecord.ConsumptionValue)
                {
                    ModelState.AddModelError(string.Empty, $"Yeni sayaç değeri, son okuma değerinden ({lastRecord.ConsumptionValue} m³) küçük olamaz!");
                    await PopulateSubscriptionsViewBag();
                    ViewBag.SelectedSubscriptionId = subscriptionId;
                    ViewBag.ConsumptionHistory = history;
                    return View();
                }
            }

            var record = new ConsumptionRecord
            {
                SubscriptionId = subscriptionId,
                ConsumptionValue = consumptionValue,
                RecordDate = recordDate ?? DateTime.Now
            };

            var json = JsonSerializer.Serialize(record);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_apiBaseUrl}/Consumption", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = $"Sayaç tüketim kaydı başarıyla eklendi: {consumptionValue} m³";
                
                return RedirectToAction("MeterReading", new { subscriptionId = subscriptionId });
            }

            ModelState.AddModelError(string.Empty, "Tüketim kaydı eklenirken hata oluştu.");
            await PopulateSubscriptionsViewBag();
            ViewBag.SelectedSubscriptionId = subscriptionId;
            ViewBag.ConsumptionHistory = new List<ConsumptionRecord>();
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> GetConsumptionHistory(int subscriptionId)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Consumption/Subscription/{subscriptionId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var records = JsonSerializer.Deserialize<List<ConsumptionRecord>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ConsumptionRecord>();
                return Json(records);
            }

            return Json(new List<ConsumptionRecord>());
        }

        
        
        
        public async Task<IActionResult> Bills()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Bill");
            var bills = new List<Bill>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                bills = JsonSerializer.Deserialize<List<Bill>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Bill>();
            }

            return View(bills);
        }

        [HttpGet]
        public async Task<IActionResult> AddBill(int? subscriptionId)
        {
            
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiBaseUrl}/Subscriptions");
            var subscriptions = new List<Subscription>();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                subscriptions = JsonSerializer.Deserialize<List<Subscription>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Subscription>();
            }
            ViewBag.Subscriptions = subscriptions.Where(s => s.IsActive).ToList();
            ViewBag.SelectedSubscriptionId = subscriptionId ?? 0;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBill(Bill bill)
        {
            bill.CreatedDate = DateTime.Now;
            bill.Status = "Ödenmedi";

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(bill);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_apiBaseUrl}/Bill", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Fatura başarıyla oluşturuldu.";
                return RedirectToAction("Bills");
            }

            
            var subResp = await client.GetAsync($"{_apiBaseUrl}/Subscriptions");
            var subscriptions = new List<Subscription>();
            if (subResp.IsSuccessStatusCode)
            {
                var subJson = await subResp.Content.ReadAsStringAsync();
                subscriptions = JsonSerializer.Deserialize<List<Subscription>>(subJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Subscription>();
            }
            ViewBag.Subscriptions = subscriptions.Where(s => s.IsActive).ToList();
            ViewBag.SelectedSubscriptionId = bill.SubscriptionId;
            ModelState.AddModelError(string.Empty, "Fatura oluşturulurken hata oluştu.");
            return View(bill);
        }
    }
}
