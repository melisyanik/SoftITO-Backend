using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace SmartMunicipality.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _efApiUrl = "http://localhost:5010/api";
        private readonly string _dapperApiUrl = "http://localhost:5298/api";

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Users));
        }

        
        public async Task<IActionResult> Users()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_efApiUrl}/User");
            var users = new List<JsonElement>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                users = JsonSerializer.Deserialize<List<JsonElement>>(jsonString) ?? new List<JsonElement>();
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_efApiUrl}/User/{id}");

            if (!response.IsSuccessStatusCode) return NotFound();

            var jsonString = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<JsonElement>(jsonString);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string name, string surname, string email, string phoneNumber, string tcNo, string address, string district, string role)
        {
            var payload = new
            {
                id = id,
                name = name,
                surname = surname,
                email = email,
                phoneNumber = phoneNumber,
                tcNo = tcNo,
                address = address,
                district = district,
                role = role
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{_efApiUrl}/User/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kullanıcı bilgileri başarıyla güncellendi.";
                return RedirectToAction("Users");
            }

            ModelState.AddModelError(string.Empty, "Kullanıcı güncellenirken hata oluştu.");
            return View(payload);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_efApiUrl}/User/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kullanıcı başarıyla silindi.";
            }
            else
            {
                TempData["Message"] = "Kullanıcı silinemedi.";
            }

            return RedirectToAction("Users");
        }

        
        public async Task<IActionResult> ComplaintCategories()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_efApiUrl}/Complaints/Categories");
            var categories = new List<SmartMunicipality.MODEL.ComplaintCategory>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                categories = JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.ComplaintCategory>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.ComplaintCategory>();
            }

            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> AddComplaintCategory(string name, string description)
        {
            var payload = new
            {
                Name = name,
                Description = description
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_efApiUrl}/Complaints/Categories", stringContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Yeni kategori başarıyla eklendi.";
            }
            else
            {
                TempData["Message"] = "Kategori eklenirken hata oluştu.";
            }

            return RedirectToAction("ComplaintCategories");
        }

        [HttpPost]
        public async Task<IActionResult> EditComplaintCategory(int id, string name, string description)
        {
            var payload = new
            {
                Id = id,
                Name = name,
                Description = description
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{_efApiUrl}/Complaints/Categories/{id}", stringContent);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kategori başarıyla güncellendi.";
            }
            else
            {
                TempData["Message"] = "Kategori güncellenirken hata oluştu.";
            }

            return RedirectToAction("ComplaintCategories");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComplaintCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_efApiUrl}/Complaints/Categories/{id}");

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Kategori başarıyla silindi.";
            }
            else
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                try 
                {
                    using var doc = JsonDocument.Parse(responseContent);
                    if (doc.RootElement.TryGetProperty("message", out var msgProp))
                    {
                        TempData["Error"] = msgProp.GetString();
                    }
                    else
                    {
                        TempData["Error"] = "Kategori silinemedi. Bu kategoriye ait aktif şikayetler olabilir.";
                    }
                }
                catch
                {
                    TempData["Error"] = "Kategori silinemedi. Bu kategoriye ait aktif şikayetler olabilir.";
                }
            }

            return RedirectToAction("ComplaintCategories");
        }

        
        public async Task<IActionResult> Announcements()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_efApiUrl}/Announcements");
            var announcements = new List<SmartMunicipality.MODEL.Announcement>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                announcements = JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.Announcement>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.Announcement>();
            }

            return View(announcements);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(string title, string content)
        {
            var payload = new
            {
                Title = title,
                Content = content,
                PublishDate = DateTime.Now,
                IsActive = true
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync($"{_efApiUrl}/Announcements", stringContent);

            TempData["Message"] = "Yeni duyuru başarıyla yayınlandı.";
            return RedirectToAction("Announcements");
        }

        [HttpPost]
        public async Task<IActionResult> EditAnnouncement(int id, string title, string content)
        {
            var payload = new
            {
                Id = id,
                Title = title,
                Content = content,
                PublishDate = DateTime.Now,
                IsActive = true
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PutAsync($"{_efApiUrl}/Announcements/{id}", stringContent);

            TempData["Message"] = "Duyuru başarıyla güncellendi.";
            return RedirectToAction("Announcements");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_efApiUrl}/Announcements/{id}");

            TempData["Message"] = "Duyuru başarıyla silindi.";
            return RedirectToAction("Announcements");
        }

        
        public async Task<IActionResult> AllComplaints()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_efApiUrl}/Complaints");
            var complaints = new List<SmartMunicipality.MODEL.Complaint>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                complaints = JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.Complaint>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.Complaint>();
            }

            return View(complaints);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComplaint(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync($"{_efApiUrl}/Complaints/{id}");

            TempData["Message"] = "Şikayet başarıyla silindi.";
            return RedirectToAction("Complaints", "Operator");
        }

        
        public async Task<IActionResult> HeatMap()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_dapperApiUrl}/Reports/HeatMapData");
            var points = new List<JsonElement>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                points = JsonSerializer.Deserialize<List<JsonElement>>(jsonString) ?? new List<JsonElement>();
            }

            return View(points);
        }

        
        public async Task<IActionResult> Reports()
        {
            var client = _httpClientFactory.CreateClient();
            var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            
            var statsResp = await client.GetAsync($"{_dapperApiUrl}/Reports/DashboardStats");
            var stats = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            if (statsResp.IsSuccessStatusCode)
            {
                var str = await statsResp.Content.ReadAsStringAsync();
                var raw = JsonSerializer.Deserialize<Dictionary<string, int>>(str, opts);
                if (raw != null)
                    foreach (var kv in raw) stats[kv.Key] = kv.Value;
            }

            
            var catResp = await client.GetAsync($"{_dapperApiUrl}/Reports/ComplaintsByCategory");
            var catData = new List<dynamic>();
            if (catResp.IsSuccessStatusCode)
            {
                catData = JsonSerializer.Deserialize<List<dynamic>>(await catResp.Content.ReadAsStringAsync(), opts) ?? new List<dynamic>();
            }

            
            var distResp = await client.GetAsync($"{_dapperApiUrl}/Reports/ComplaintsByDistrict");
            var distData = new List<dynamic>();
            if (distResp.IsSuccessStatusCode)
            {
                distData = JsonSerializer.Deserialize<List<dynamic>>(await distResp.Content.ReadAsStringAsync(), opts) ?? new List<dynamic>();
            }

            
            var revResp = await client.GetAsync($"{_dapperApiUrl}/Reports/MonthlyRevenue");
            var revData = new List<dynamic>();
            if (revResp.IsSuccessStatusCode)
            {
                revData = JsonSerializer.Deserialize<List<dynamic>>(await revResp.Content.ReadAsStringAsync(), opts) ?? new List<dynamic>();
            }

            
            var statusResp = await client.GetAsync($"{_dapperApiUrl}/Reports/ComplaintsByStatus");
            var statusData = new List<dynamic>();
            if (statusResp.IsSuccessStatusCode)
            {
                statusData = JsonSerializer.Deserialize<List<dynamic>>(await statusResp.Content.ReadAsStringAsync(), opts) ?? new List<dynamic>();
            }

            ViewBag.Stats = stats;
            ViewBag.Categories = catData;
            ViewBag.Districts = distData;
            ViewBag.Revenue = revData;
            ViewBag.ComplaintStatuses = statusData;

            return View();
        }
    }
}
