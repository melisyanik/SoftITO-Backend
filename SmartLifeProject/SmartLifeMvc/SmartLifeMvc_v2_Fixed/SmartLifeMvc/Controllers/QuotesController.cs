using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartLifeMvc.ViewModels.Api;
using System.Text;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public QuotesController(IHttpClientFactory httpClientFactory)
            => _httpClientFactory = httpClientFactory;

        private HttpClient Client => _httpClientFactory.CreateClient("SmartLifeApi");

        public async Task<IActionResult> Index(string? search)
        {
            List<QuoteDto> quotes;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var resp = await Client.GetAsync($"Quotes/SearchQuotes?keyword={Uri.EscapeDataString(search)}");
                quotes = JsonConvert.DeserializeObject<List<QuoteDto>>(await resp.Content.ReadAsStringAsync()) ?? new();
            }
            else
            {
                var resp = await Client.GetAsync("Quotes/GetQuotes");
                quotes = JsonConvert.DeserializeObject<List<QuoteDto>>(await resp.Content.ReadAsStringAsync()) ?? new();
            }

            ViewBag.Search = search;
            return View(quotes);
        }

        [HttpGet]
        public IActionResult Create() => View(new QuoteDto());

        [HttpPost]
        public async Task<IActionResult> Create(QuoteDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var payload = JsonConvert.SerializeObject(new { model.Text, model.Author });
            await Client.PostAsync("Quotes/AddQuotes", new StringContent(payload, Encoding.UTF8, "application/json"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var resp = await Client.GetAsync($"Quotes/GetQuotesById/{id}");
            var quote = JsonConvert.DeserializeObject<QuoteDto>(await resp.Content.ReadAsStringAsync());
            if (quote == null) return NotFound();
            return View(quote);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(QuoteDto model)
        {
            var payload = JsonConvert.SerializeObject(new { model.Text, model.Author });
            await Client.PutAsync($"Quotes/UpdateQuotes/{model.Id}", new StringContent(payload, Encoding.UTF8, "application/json"));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync($"Quotes/DeleteQuotes/{id}");
            return RedirectToAction("Index");
        }
    }
}
