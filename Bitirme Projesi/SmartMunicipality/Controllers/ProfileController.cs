using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SmartMunicipality.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using SmartMunicipality.Models;

namespace SmartMunicipality.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProfileController(IHttpClientFactory httpClientFactory)
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
            var token = User.FindFirstValue("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.GetAsync($"http://localhost:5010/api/Profile/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<ProfileViewModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(model);
            }

            TempData["Error"] = "Profil bilgileri yüklenemedi. Lütfen tekrar deneyin.";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var client = _httpClientFactory.CreateClient();
            var token = User.FindFirstValue("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            var response = await client.GetAsync($"http://localhost:5010/api/Profile/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<ProfileViewModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(model);
            }

            TempData["Error"] = "Profil bilgileri yüklenemedi.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub") ?? string.Empty;
            var client = _httpClientFactory.CreateClient();
            var token = User.FindFirstValue("JWToken");
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }

            var payload = new {
                model.Name,
                model.Surname,
                model.TcNo,
                model.Phone,
                model.Address,
                model.District
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"http://localhost:5010/api/Profile/{userId}", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "Profil bilgileriniz başarıyla güncellendi.";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", "Profil güncellenirken bir hata oluştu.");
            return View(model);
        }
    }
}
