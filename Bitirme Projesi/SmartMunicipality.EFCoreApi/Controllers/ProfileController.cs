using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.MODEL;
using System.Threading.Tasks;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = "User not found" });

            return Ok(new
            {
                user.Id,
                user.Name,
                user.Surname,
                user.TcNo,
                Phone = user.PhoneNumber,
                user.Address,
                user.District,
                user.Email
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] ProfileUpdateDto dto)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = "User not found" });

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.TcNo = dto.TcNo;
            user.PhoneNumber = dto.Phone;
            user.Address = dto.Address;
            user.District = dto.District;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Ok(new { Message = "Profile updated successfully" });

            return BadRequest(result.Errors);
        }
    }

    public class ProfileUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string TcNo { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
    }
}
