using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmartLifeMvc.ViewModels.Api;
using System.Text;

namespace SmartLifeMvc.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TasksController(IHttpClientFactory httpClientFactory)
            => _httpClientFactory = httpClientFactory;

        private HttpClient Client => _httpClientFactory.CreateClient("SmartLifeApi");

        public async Task<IActionResult> Index(string? search, string? priority, string? status)
        {
            List<TaskDto> tasks;

            if (!string.IsNullOrWhiteSpace(search))
            {
                var resp = await Client.GetAsync($"Tasks/SearchTasks?keyword={Uri.EscapeDataString(search)}");
                tasks = JsonConvert.DeserializeObject<List<TaskDto>>(await resp.Content.ReadAsStringAsync()) ?? new();
            }
            else
            {
                var resp = await Client.GetAsync("Tasks/GetTasks");
                tasks = JsonConvert.DeserializeObject<List<TaskDto>>(await resp.Content.ReadAsStringAsync()) ?? new();
            }

            if (!string.IsNullOrEmpty(priority))
                tasks = tasks.Where(t => t.Priority == priority).ToList();

            if (status == "done") tasks = tasks.Where(t => t.IsCompleted).ToList();
            else if (status == "active") tasks = tasks.Where(t => !t.IsCompleted).ToList();

            ViewBag.Search = search;
            ViewBag.Priority = priority;
            ViewBag.Status = status;
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create() => View(new TaskDto());

        [HttpPost]
        public async Task<IActionResult> Create(TaskDto model)
        {
            if (!ModelState.IsValid) return View(model);
            var payload = JsonConvert.SerializeObject(new { model.Title, model.Priority, model.IsCompleted });
            await Client.PostAsync("Tasks/AddTasks", new StringContent(payload, Encoding.UTF8, "application/json"));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var resp = await Client.GetAsync($"Tasks/GetTasksById/{id}");
            var task = JsonConvert.DeserializeObject<TaskDto>(await resp.Content.ReadAsStringAsync());
            if (task == null) return NotFound();
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskDto model)
        {
            var payload = JsonConvert.SerializeObject(new { model.Title, model.Priority, model.IsCompleted });
            await Client.PutAsync($"Tasks/UpdateTasks/{model.Id}", new StringContent(payload, Encoding.UTF8, "application/json"));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Toggle(int id)
        {
            var resp = await Client.GetAsync($"Tasks/GetTasksById/{id}");
            var task = JsonConvert.DeserializeObject<TaskDto>(await resp.Content.ReadAsStringAsync());
            if (task == null) return NotFound();

            task.IsCompleted = !task.IsCompleted;
            var payload = JsonConvert.SerializeObject(new { task.Title, task.Priority, task.IsCompleted });
            await Client.PutAsync($"Tasks/UpdateTasks/{id}", new StringContent(payload, Encoding.UTF8, "application/json"));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await Client.DeleteAsync($"Tasks/DeleteTasks/{id}");
            return RedirectToAction("Index");
        }
    }
}
