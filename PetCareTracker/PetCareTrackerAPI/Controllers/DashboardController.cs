using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTracker.Api.DTOs.Dashboard;
using PetCareTracker.Api.Repositories;

namespace PetCareTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly BaseRepository _repo;

        public DashboardController(BaseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _repo.QueryFirstOrDefault<DashboardDto>("sp_Dashboard_Get");
            return Ok(result);
        }

        [HttpGet("vaccinations")]
        public async Task<IActionResult> Vaccinations()
        {
            var result = await _repo.Query<UpcomingVaccinationDto>("sp_Report_UpcomingVaccinations");
            return Ok(result);
        }

        [HttpGet("appointments")]
        public async Task<IActionResult> Appointments()
        {
            var result = await _repo.Query<UpcomingAppointmentDto>("sp_Report_UpcomingAppointments");
            return Ok(result);
        }

        [HttpGet("pet/{id}")]
        public async Task<IActionResult> PetReport(int id)
        {
            var result = await _repo.Query<PetReportDto>(
                "sp_Report_PetDetail",
                new { PetId = id });

            return Ok(result);
        }
    }
}
