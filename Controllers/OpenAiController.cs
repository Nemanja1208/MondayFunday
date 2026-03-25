using Microsoft.AspNetCore.Mvc;
using MondayFunday.Models;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Controllers
{
    [Route("api/openai")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private readonly IOpenAiInterface _openAiService;

        public OpenAiController(IOpenAiInterface openAiService)
        {
            _openAiService = openAiService;
        }

        // POST: api/openai/chat
        [HttpPost("chat")]
        public async Task<ActionResult<ChatResponse>> Chat([FromBody] ChatRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Message cannot be empty");

            var response = await _openAiService.Chat(request.Message);
            return Ok(response);
        }
    }
}
