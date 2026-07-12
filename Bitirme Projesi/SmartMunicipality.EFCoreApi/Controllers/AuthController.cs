using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.EFCoreApi.DTOs.AuthDtos;
using SmartMunicipality.EFCoreApi.Services;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtService _jwtService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            
            var userExists = await _userManager.FindByEmailAsync(dto.Email);
            if (userExists != null)
                return BadRequest(new { Message = "Bu email adresi zaten kullanılıyor." });

            ApplicationUser user = new ApplicationUser()
            {
                Email = dto.Email,
                UserName = dto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = dto.Name,
                Surname = dto.Surname,
                PhoneNumber = dto.PhoneNumber,
                TcNo = dto.TcNo,
                Address = dto.Address,
                District = dto.District
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new { Message = "Kullanıcı oluşturulamadı.", Errors = errors });
            }

            
            string assignedRole = "Citizen"; 

            if (dto.Email.EndsWith("@belediye.bel.tr", StringComparison.OrdinalIgnoreCase))
            {
                assignedRole = "Admin";
            }
            else if (dto.Email.EndsWith("@operator.bel.tr", StringComparison.OrdinalIgnoreCase))
            {
                assignedRole = "Operator";
            }

            if (!await _roleManager.RoleExistsAsync(assignedRole))
                await _roleManager.CreateAsync(new IdentityRole(assignedRole));

            await _userManager.AddToRoleAsync(user, assignedRole);

            return Ok(new { Message = "Kullanıcı başarıyla oluşturuldu.", Role = assignedRole });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var tokenString = _jwtService.GenerateToken(user, userRoles);

                return Ok(new
                {
                    Token = tokenString,
                    Expiration = DateTime.UtcNow.AddMinutes(60) 
                });
            }

            return Unauthorized(new { Message = "Email veya şifre hatalı." });
        }
    }
}
