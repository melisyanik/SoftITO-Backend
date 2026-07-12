using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SmartMunicipality.DATA.IRepository;
using SmartMunicipality.MODEL;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ComplaintsController> _logger;

        public ComplaintsController(IUnitOfWork unitOfWork, IMemoryCache cache, ILogger<ComplaintsController> logger)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
            _logger = logger;
        }

        
        [HttpGet]
        public IActionResult GetComplaints()
        {
            _logger.LogInformation("GetComplaints endpoint called");

            const string cacheKey = "complaintsList";

            if (!_cache.TryGetValue(cacheKey, out IEnumerable<Complaint>? complaints))
            {
                _logger.LogInformation("Cache miss. Fetching from database...");
                complaints = _unitOfWork.Complaint.GetAll(includeProperties: "Category,Status,Responses");

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

                _cache.Set(cacheKey, complaints, cacheOptions);
            }
            else
            {
                _logger.LogInformation("Returning data from cache.");
            }

            return Ok(complaints);
        }

        
        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            var categories = _unitOfWork.ComplaintCategory.GetAll();
            return Ok(categories);
        }

        
        [HttpGet("Categories/{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _unitOfWork.ComplaintCategory.GetFirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound(new { Message = "Kategori bulunamadı." });
            return Ok(category);
        }

        
        [HttpPost("Categories")]
        public IActionResult PostCategory([FromBody] ComplaintCategory category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            _unitOfWork.ComplaintCategory.Add(category);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        
        [HttpPut("Categories/{id}")]
        public IActionResult PutCategory(int id, [FromBody] ComplaintCategory category)
        {
            if (id != category.Id) return BadRequest(new { Message = "ID uyumsuzluğu." });

            var existing = _unitOfWork.ComplaintCategory.GetFirstOrDefault(c => c.Id == id);
            if (existing == null) return NotFound();

            existing.Name = category.Name;
            existing.Description = category.Description;

            _unitOfWork.ComplaintCategory.Update(existing);
            _unitOfWork.Save();
            return NoContent();
        }

        
        [HttpDelete("Categories/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _unitOfWork.ComplaintCategory.GetFirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            var hasComplaints = _unitOfWork.Complaint.GetFirstOrDefault(c => c.CategoryId == id) != null;
            if (hasComplaints)
            {
                return BadRequest(new { Message = "Bu kategoriye ait aktif şikayetler bulunduğundan silinemez." });
            }

            _unitOfWork.ComplaintCategory.Remove(category);
            _unitOfWork.Save();
            return NoContent();
        }

        
        [HttpGet("{id}")]
        public IActionResult GetComplaint(int id)
        {
            var complaint = _unitOfWork.Complaint.GetFirstOrDefault(c => c.Id == id, includeProperties: "Category,Status,Responses");

            if (complaint == null)
            {
                return NotFound(new { Message = "Şikayet bulunamadı." });
            }

            return Ok(complaint);
        }

        public class ComplaintCreateDto
        {
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Phone { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public int CategoryId { get; set; }
            public string UserId { get; set; } = string.Empty;
            public double Latitude { get; set; }
            public double Longitude { get; set; }
        }

        
        [HttpPost]
        public IActionResult PostComplaint([FromBody] ComplaintCreateDto dto)
        {
            _logger.LogInformation("PostComplaint endpoint called to add a new complaint.");

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var complaint = new Complaint
            {
                Title = dto.Title,
                Description = dto.Description,
                Phone = dto.Phone,
                Address = dto.Address,
                CategoryId = dto.CategoryId,
                UserId = dto.UserId,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                CreatedDate = DateTime.Now,
                StatusId = 1 
            };

            _unitOfWork.Complaint.Add(complaint);
            _unitOfWork.Save();

            _logger.LogInformation("New complaint added successfully. Invalidating cache.");
            _cache.Remove("complaintsList");

            return CreatedAtAction(nameof(GetComplaint), new { id = complaint.Id }, complaint);
        }

        
        [HttpPut("{id}")]
        public IActionResult PutComplaint(int id, [FromBody] Complaint complaint)
        {
            if (id != complaint.Id)
            {
                return BadRequest(new { Message = "ID uyumsuzluğu." });
            }

            var existing = _unitOfWork.Complaint.GetFirstOrDefault(c => c.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            
            existing.Title = complaint.Title;
            existing.Description = complaint.Description;
            existing.CategoryId = complaint.CategoryId;
            existing.StatusId = complaint.StatusId;
            existing.Address = complaint.Address;
            existing.Latitude = complaint.Latitude;
            existing.Longitude = complaint.Longitude;
            existing.Phone = complaint.Phone;

            _unitOfWork.Complaint.Update(existing);
            _unitOfWork.Save();

            _cache.Remove("complaintsList");

            return NoContent();
        }

        
        [HttpPost("{id}/Respond")]
        public IActionResult RespondToComplaint(int id, [FromBody] ComplaintResponse response)
        {
            var complaint = _unitOfWork.Complaint.GetFirstOrDefault(c => c.Id == id);
            if (complaint == null)
            {
                return NotFound(new { Message = "Şikayet bulunamadı." });
            }

            response.ComplaintId = id;
            response.CreatedDate = DateTime.Now;

            _unitOfWork.ComplaintResponse.Add(response);
            _unitOfWork.Save();

            _cache.Remove("complaintsList");

            return Ok(new { Message = "Cevap başarıyla eklendi." });
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteComplaint(int id)
        {
            var complaint = _unitOfWork.Complaint.GetFirstOrDefault(c => c.Id == id);
            if (complaint == null)
            {
                return NotFound();
            }

            
            var responses = _unitOfWork.ComplaintResponse.GetAll(r => r.ComplaintId == id);
            if (responses != null && responses.Any())
            {
                _unitOfWork.ComplaintResponse.RemoveRange(responses);
            }

            
            _unitOfWork.Complaint.Remove(complaint);
            _unitOfWork.Save();

            
            _cache.Remove("complaintsList");

            return NoContent();
        }
    }
}
