using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTracker.Api.DTOs.Vaccinations;
using PetCareTracker.Api.Repositories;

namespace PetCareTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VaccinationController : ControllerBase
    {
        private readonly BaseRepository _repo;

        public VaccinationController(BaseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("pet/{petId}")]
        public async Task<IActionResult> GetByPet(int petId)
        {
            var result = await _repo.Query<VaccinationDto>(
                "sp_Vaccination_ListByPet",
                new { PetId = petId });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.QueryFirstOrDefault<VaccinationDto>(
                "sp_Vaccination_GetById",
                new { VaccinationId = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await _repo.Query<VaccinationDto>(
                "sp_Vaccination_Search",
                new { Keyword = keyword });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VaccinationDto dto)
        {
            await _repo.Execute("sp_Vaccination_Add", new
            {
                dto.PetId,
                dto.VaccineName,
                dto.VaccinationDate,
                dto.NextDueDate,
                dto.Notes
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VaccinationDto dto)
        {
            await _repo.Execute("sp_Vaccination_Update", new
            {
                dto.VaccinationId,
                dto.VaccineName,
                dto.VaccinationDate,
                dto.NextDueDate,
                dto.Notes
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Vaccination_Delete", new { VaccinationId = id });
            return Ok();
        }
    }
}
