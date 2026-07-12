using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.Models;
using System.Text;
using System.Text.Json;
using System.Security.Claims;

namespace SmartMunicipality.Controllers
{
    public class ComplaintsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "http://localhost:5010/api/Complaints";

        public ComplaintsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync(_apiUrl);

            var complaints = new List<ComplaintViewModel>();

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                complaints = JsonSerializer.Deserialize<List<ComplaintViewModel>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<ComplaintViewModel>();
                
                
                if (!User.IsInRole("Admin") && !User.IsInRole("Operator"))
                {
                    complaints = complaints.Where(c => c.UserId == userId).ToList();
                }
            }

            return View(complaints);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategoriesViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateComplaintViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateCategoriesViewBag();
                return View(model);
            }

            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            
            
            double latitude = 0;
            double longitude = 0;
            if (double.TryParse(Request.Form["Latitude"], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var lat))
            {
                latitude = lat;
            }
            else
            {
                latitude = model.Latitude;
            }

            if (double.TryParse(Request.Form["Longitude"], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var lng))
            {
                longitude = lng;
            }
            else
            {
                longitude = model.Longitude;
            }

            var payload = new {
                Title = model.Title,
                Description = model.Description,
                Address = model.Address,
                Phone = model.Phone,
                CategoryId = model.CategoryId,
                UserId = userId,
                Latitude = latitude,
                Longitude = longitude
            };

            var client = _httpClientFactory.CreateClient();
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_apiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Şikayetiniz başarıyla oluşturuldu!";
                return RedirectToAction("Index");
            }

            await PopulateCategoriesViewBag();
            ModelState.AddModelError(string.Empty, "Şikayet oluşturulurken bir hata oluştu.");
            return View(model);
        }

        private async Task PopulateCategoriesViewBag()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("http://localhost:5010/api/Complaints/Categories");
                var categories = new List<SmartMunicipality.MODEL.ComplaintCategory>();

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<SmartMunicipality.MODEL.ComplaintCategory>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<SmartMunicipality.MODEL.ComplaintCategory>();
                }

                ViewBag.Categories = categories;
            }
            catch
            {
                ViewBag.Categories = new List<SmartMunicipality.MODEL.ComplaintCategory>();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiUrl}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var complaint = JsonSerializer.Deserialize<SmartMunicipality.MODEL.Complaint>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
                if (complaint != null && (User.IsInRole("Admin") || User.IsInRole("Operator") || complaint.UserId == userId))
                {
                    return View(complaint);
                }
            }

            return NotFound();
        }
    }
}
