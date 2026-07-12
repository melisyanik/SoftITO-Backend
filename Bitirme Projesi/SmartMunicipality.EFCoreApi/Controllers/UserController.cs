using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SmartMunicipality.Data.ApplicationDbContext _context;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SmartMunicipality.Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public class UserDto
        {
            public string Id { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Surname { get; set; } = string.Empty;
            public string? PhoneNumber { get; set; }
            public string? TcNo { get; set; }
            public string? Address { get; set; }
            public string? District { get; set; }
            public string Role { get; set; } = string.Empty;
        }

        public class UserCreateDto
        {
            public string Email { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string Name { get; set; } = string.Empty;
            public string Surname { get; set; } = string.Empty;
            public string? PhoneNumber { get; set; }
            public string? TcNo { get; set; }
            public string? Address { get; set; }
            public string? District { get; set; }
            public string Role { get; set; } = "Citizen";
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var dtoList = new List<UserDto>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                dtoList.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email ?? string.Empty,
                    Name = user.Name,
                    Surname = user.Surname,
                    PhoneNumber = user.PhoneNumber,
                    TcNo = user.TcNo,
                    Address = user.Address,
                    District = user.District,
                    Role = roles.FirstOrDefault() ?? "Citizen"
                });
            }

            return Ok(dtoList);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new UserDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                TcNo = user.TcNo,
                Address = user.Address,
                District = user.District,
                Role = roles.FirstOrDefault() ?? "Citizen"
            });
        }

        
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _userManager.FindByEmailAsync(dto.Email);
            if (existing != null) return BadRequest(new { Message = "Bu email adresi zaten kullanılıyor." });

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Name = dto.Name,
                Surname = dto.Surname,
                PhoneNumber = dto.PhoneNumber,
                TcNo = dto.TcNo,
                Address = dto.Address,
                District = dto.District,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Kullanıcı oluşturulamadı.", Errors = result.Errors.Select(e => e.Description) });
            }

            
            if (!await _roleManager.RoleExistsAsync(dto.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(dto.Role));
            }
            await _userManager.AddToRoleAsync(user, dto.Role);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                TcNo = user.TcNo,
                Address = user.Address,
                District = user.District,
                Role = dto.Role
            });
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, [FromBody] UserDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            user.Name = dto.Name;
            user.Surname = dto.Surname;
            user.PhoneNumber = dto.PhoneNumber;
            user.TcNo = dto.TcNo;
            user.Address = dto.Address;
            user.District = dto.District;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors);

            
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(dto.Role))
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!await _roleManager.RoleExistsAsync(dto.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(dto.Role));
                }
                await _userManager.AddToRoleAsync(user, dto.Role);
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            
            var notifications = await _context.Notifications.Where(n => n.UserId == id).ToListAsync();
            _context.Notifications.RemoveRange(notifications);

            
            var complaints = await _context.Complaints.Where(c => c.UserId == id).ToListAsync();
            foreach (var complaint in complaints)
            {
                var responses = await _context.ComplaintResponses.Where(r => r.ComplaintId == complaint.Id).ToListAsync();
                _context.ComplaintResponses.RemoveRange(responses);
            }
            _context.Complaints.RemoveRange(complaints);

            
            var userResponses = await _context.ComplaintResponses.Where(r => r.UserId == id).ToListAsync();
            _context.ComplaintResponses.RemoveRange(userResponses);

            
            var subscriptions = await _context.Subscriptions.Where(s => s.UserId == id).ToListAsync();
            foreach (var sub in subscriptions)
            {
                var bills = await _context.Bills.Where(b => b.SubscriptionId == sub.Id).ToListAsync();
                foreach (var bill in bills)
                {
                    var payments = await _context.Payments.Where(p => p.BillId == bill.Id).ToListAsync();
                    _context.Payments.RemoveRange(payments);
                }
                _context.Bills.RemoveRange(bills);

                var consumptions = await _context.ConsumptionRecords.Where(cr => cr.SubscriptionId == sub.Id).ToListAsync();
                _context.ConsumptionRecords.RemoveRange(consumptions);
            }
            _context.Subscriptions.RemoveRange(subscriptions);

            
            await _context.SaveChangesAsync();

            
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors);

            return NoContent();
        }
    }
}
