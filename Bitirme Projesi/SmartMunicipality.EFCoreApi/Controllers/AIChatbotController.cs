using Microsoft.AspNetCore.Mvc;
using SmartMunicipality.EFCoreApi.Services;

namespace SmartMunicipality.EFCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIChatbotController : ControllerBase
    {
        private readonly IAIService _aiService;

        public AIChatbotController(IAIService aiService)
        {
            _aiService = aiService;
        }

        public class PromptRequest
        {
            public string Prompt { get; set; } = string.Empty;
        }

        
        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] PromptRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
            {
                return BadRequest(new { Message = "Lütfen geçerli bir soru yazın." });
            }

            var answer = await _aiService.AskQuestionAsync(request.Prompt);
            return Ok(new { Answer = answer });
        }
    }
}
