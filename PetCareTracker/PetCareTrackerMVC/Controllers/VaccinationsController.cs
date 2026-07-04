using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTrackerMVC.Models;
using PetCareTrackerMVC.Repositories;
using System.Security.Claims;
using System.Data;

namespace PetCareTrackerMVC.Controllers
{
    [Authorize]
    public class VaccinationsController : Controller
    {
        private readonly BaseRepository _repo;
        public VaccinationsController(BaseRepository repo) { _repo = repo; }
        private int GetUserId() => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        private bool IsAdmin() => User.IsInRole("Admin");

        public async Task<IActionResult> Index()
        {
            var pets = await _repo.Query<PetDto>("sp_Pet_List", new { UserId = GetUserId() });
            var list = new List<VaccinationDto>();
            if (IsAdmin()) {
                list = (await _repo.Query<VaccinationDto>("sp_Report_UpcomingVaccinations")).ToList();
            } else {
                foreach(var p in pets) {
                    var vacs = await _repo.Query<VaccinationDto>("sp_Vaccination_ListByPet", new { PetId = p.PetId });
                    list.AddRange(vacs);
                }
            }
            return View(list);
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
        public async Task<IActionResult> Create(VaccinationDto dto)
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

            await _repo.Execute("sp_Vaccination_Add", new { dto.PetId, dto.VaccineName, dto.VaccinationDate, dto.NextDueDate, dto.Notes });
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Vaccination_Delete", new { VaccinationId = id });
            return RedirectToAction(nameof(Index));
        }
    }
}
