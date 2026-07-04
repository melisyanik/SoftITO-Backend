using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetCareTracker.Api.DTOs.Pets;
using PetCareTracker.Api.Repositories;
using System.Security.Claims;

namespace PetCareTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetsController : ControllerBase
    {
        private readonly BaseRepository _repo;

        public PetsController(BaseRepository repo)
        {
            _repo = repo;
        }

        private int GetUserId()
            => int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pets = await _repo.Query<PetDto>(
                "sp_Pet_List",
                new { UserId = GetUserId() });

            return Ok(pets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _repo.QueryFirstOrDefault<PetDto>(
                "sp_Pet_GetById",
                new { PetId = id });

            if (pet == null)
                return NotFound();

            return Ok(pet);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string keyword)
        {
            var result = await _repo.Query<PetDto>(
                "sp_Pet_Search",
                new { Keyword = keyword, UserId = GetUserId() });

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PetDto dto)
        {
            await _repo.Execute("sp_Pet_Add", new
            {
                dto.PetName,
                dto.Species,
                dto.Breed,
                dto.Gender,
                dto.BirthDate,
                dto.Weight,
                UserId = GetUserId()
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PetDto dto)
        {
            await _repo.Execute("sp_Pet_Update", new
            {
                dto.PetId,
                dto.PetName,
                dto.Species,
                dto.Breed,
                dto.Gender,
                dto.BirthDate,
                dto.Weight
            });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.Execute("sp_Pet_Delete", new { PetId = id });
            return Ok();
        }
    }
}
