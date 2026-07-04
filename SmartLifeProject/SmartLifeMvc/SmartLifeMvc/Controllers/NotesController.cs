using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartLifeMvc.ViewModels.Api;
using System.Text;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class NotesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NotesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient Client => _httpClientFactory.CreateClient("SmartLifeApi");

        public async Task<IActionResult> Index(string? search)
        {
            List<NoteDto> notes;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var resp = await Client.GetAsync($"Notes/SearchNotes?keyword={Uri.EscapeDataString(search)}");
                var json = await resp.Content.ReadAsStringAsync();
                notes = JsonConvert.DeserializeObject<List<NoteDto>>(json) ?? new();
            }
            else
            {
                var resp = await Client.GetAsync("Notes/GetNotes");
                var json = await resp.Content.ReadAsStringAsync();
                notes = JsonConvert.DeserializeObject<List<NoteDto>>(json) ?? new();
            }

            ViewBag.Search = search;
            return View(notes);
        }

        [HttpGet]
        public IActionResult Create() => View(new NoteDto());

        [HttpPost]
        public async Task<IActionResult> Create(NoteDto model)
        {
            if (!ModelState.IsValid) return View(model);

            var payload = JsonConvert.SerializeObject(new { model.Title, model.Content });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            await Client.PostAsync("Notes/AddNotes", content);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var resp = await Client.GetAsync($"Notes/GetNotesById/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            var note = JsonConvert.DeserializeObject<NoteDto>(json);
            if (note == null) return NotFound();
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NoteDto model)
        {
            var payload = JsonConvert.SerializeObject(new { model.Title, model.Content });
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            await Client.PutAsync($"Notes/UpdateNotes/{model.Id}", content);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync($"Notes/DeleteNotes/{id}");
            return RedirectToAction("Index");
        }
    }
}
