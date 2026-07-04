using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTracker.Api.DTOs.Appointments;
using PetCareTracker.Api.Repositories;

namespace PetCareTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly BaseRepository _repo;

        public AppointmentsController(BaseRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AppointmentDto dto)
        {
            await _repo.Execute("sp_Appointment_Add", new
            {
                dto.PetId,
                dto.AppointmentDate,
                dto.Veterinarian,
                dto.Notes
            });

            return Ok("Appointment added");
        }

        [HttpGet("list/{petId}")]
        public async Task<IActionResult> List(int petId)
        {
            var result = await _repo.Query<AppointmentDto>(
                "sp_Appointment_ListByPet",
                new { PetId = petId });

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await _repo.Query<AppointmentDto>(
                "sp_Appointment_Search",
                new { Keyword = keyword });

            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            await _repo.Execute("sp_Appointment_UpdateStatus", new
            {
                AppointmentId = id,
                Status        = status
            });

            return Ok("Status updated");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Appointment_Delete", new { AppointmentId = id });
            return Ok("Deleted");
        }
    }
}
