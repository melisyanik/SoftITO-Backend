using Microsoft.AspNetCore.Mvc;
using PetCareTracker.Api.DTOs.Auth;
using PetCareTracker.Api.Helpers;
using PetCareTracker.Api.Models;
using PetCareTracker.Api.Repositories;

namespace PetCareTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BaseRepository _repo;
        private readonly JwtHelper _jwt;

        public AuthController(BaseRepository repo, JwtHelper jwt)
        {
            _repo = repo;
            _jwt  = jwt;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            try
            {
                await _repo.Execute("sp_User_Register", new
                {
                    dto.FullName,
                    dto.Email,
                    PasswordHash = hash
                });

                return Ok("User created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _repo.QueryFirstOrDefault<User>(
                "sp_User_Login",
                new { dto.Email });

            if (user == null)
                return Unauthorized("Invalid email");

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);

            if (!isValid)
                return Unauthorized("Invalid password");

            var token = _jwt.GenerateToken(user);

            return Ok(new UserResponseDto
            {
                UserId   = user.UserId,
                FullName = user.FullName,
                Email    = user.Email,
                Role     = user.Role,
                Token    = token
            });
        }
    }
}
