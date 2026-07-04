using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTrackerMVC.Models;
using PetCareTrackerMVC.Repositories;
using System.Security.Claims;
using System.Data;

namespace PetCareTrackerMVC.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly BaseRepository _repo;
        public AppointmentsController(BaseRepository repo) { _repo = repo; }
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        private bool IsAdmin() => User.IsInRole("Admin");

        public async Task<IActionResult> Index()
        {
            IEnumerable<AppointmentDto> appointments;
            if (IsAdmin()) {
                appointments = await _repo.Query<AppointmentDto>("sp_Report_UpcomingAppointments");
            } else {
                var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
                var list = new List<AppointmentDto>();
                foreach(var p in pets) {
                    var apps = await _repo.Query<AppointmentDto>("sp_Appointment_ListByPet", new { PetId = p.PetId });
                    list.AddRange(apps);
                }
                appointments = list;
            }
            return View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var pets = IsAdmin() 
                ? await _repo.Query<PetDto>("SELECT * FROM Pets", cmdType: CommandType.Text)
                : await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            ViewBag.Pets = pets;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto dto)
        {
            if (!IsAdmin() && !string.IsNullOrWhiteSpace(dto.PetName))
            {
                var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
                var pet = pets.FirstOrDefault(p => p.PetName.Equals(dto.PetName, StringComparison.OrdinalIgnoreCase));
                if (pet == null)
                {
                    await _repo.Execute("sp_Pet_Add", new { PetName = dto.PetName, Species = "Bilinmiyor", Breed = "", Gender = "", BirthDate = (DateTime?)null, Weight = (decimal?)null, UserId = GetUserId() });
                    pet = (await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() })).FirstOrDefault(p => p.PetName.Equals(dto.PetName, StringComparison.OrdinalIgnoreCase));
                }
                if (pet != null) dto.PetId = pet.PetId;
            }

            await _repo.Execute("sp_Appointment_Add", new { dto.PetId, dto.AppointmentDate, dto.Veterinarian, dto.Notes });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await _repo.Execute("sp_Appointment_UpdateStatus", new { AppointmentId = id, Status = status });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Appointment_Delete", new { AppointmentId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
