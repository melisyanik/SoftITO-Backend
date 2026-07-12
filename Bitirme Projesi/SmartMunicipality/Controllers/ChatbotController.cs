using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace SmartMunicipality.Controllers
{
    public class ChatbotController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiUrl = "http://localhost:5010/api/AIChatbot/ask";

        public ChatbotController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                return Json(new { answer = "Lütfen geçerli bir soru yazın." });
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                var payload = new { Prompt = prompt };
                var json = JsonSerializer.Serialize(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    using var doc = JsonDocument.Parse(responseString);
                    var answer = doc.RootElement.GetProperty("answer").GetString();
                    return Json(new { answer = answer });
                }
            }
            catch
            {
                
                return Json(new { answer = "Sistem şu anda geçici olarak yanıt veremiyor. Lütfen daha sonra tekrar deneyiniz." });
            }

            return Json(new { answer = "Üzgünüm, sorunuza cevap bulamadım. Lütfen daha sonra tekrar deneyin." });
        }
    }
}
