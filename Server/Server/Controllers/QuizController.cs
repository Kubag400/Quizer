using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("[controller]")]
    public class QuizController(IQuizService quizService, ILogger<QuizController> logger) : ControllerBase
    {
        public ILogger<QuizController> _logger { get; } = logger;

        [HttpGet("quizzesByTopic")]
        public async Task<IActionResult> GetQuizzesByTopic(string topic)
        {
            var result =  await quizService.GetQuizzesByTopic(topic);
            if(result.Value.Count > 0)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuiz([FromBody] AddQuizRequest request)
        {
            //TODO: Validation
            var result = await quizService.CreateQuiz(request);

            if (result.IsSuccess)
                return Ok();
            return BadRequest();
        }

        [HttpGet("GetQuizWithDetails")]
        public async Task<IActionResult> GetQuizWithDetails([FromQuery] string quizId)
        {
            //TODO: proper responses
            if (string.IsNullOrEmpty(quizId))
            {
                return BadRequest("Cannot insert empty quiz id");
            }

            var result = await quizService.GetQuizDetails(quizId);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return NotFound();
        }

        [HttpGet("GetQuizzes")]
        public async Task<IActionResult> GetQuizzes()
        {
            _logger.LogInformation("GetQuizzes called");
            var result = await quizService.GetAllQuizzes();
            if (result.IsSuccess)
            {
                _logger.LogInformation($"QuizResponse {result.Value}");
                return Ok(result.Value);
            }
            return BadRequest();
        }
    }
}
