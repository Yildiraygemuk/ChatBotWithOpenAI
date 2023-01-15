using ChatBotWithOpenAI.Model;
using ChatBotWithOpenAI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotWithOpenAI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IOpenAICompletionService _openAICompletionService;

        public ChatBotController(IOpenAICompletionService openAICompletionService)
        {
            _openAICompletionService = openAICompletionService;
        }

        [HttpPost]
        public IActionResult AskQuestion(QuestionVm questionVm)
        {
            var result = _openAICompletionService.CallAPI(questionVm);
            return Ok(result);
        }
    }
}
