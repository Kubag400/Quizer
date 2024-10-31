using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class QuizzController : ControllerBase
    {
        private readonly IQuizzService _quizzService;
        public QuizzController(IQuizzService quizzService)
        {
            _quizzService = quizzService;
        }
        [HttpGet("quizzesByTopic")]
        public async Task<IActionResult> GetQuizzesByTopic(string topic)
        {
            var result =  await _quizzService.GetQuizzesByTopic(topic);
            if(result.Value.Count > 0)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuizz([FromBody] AddQuizzRequest request)
        {
            //TODO: Validation
            var result = await _quizzService.CreateQuizz(request);

            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }
    }
}
