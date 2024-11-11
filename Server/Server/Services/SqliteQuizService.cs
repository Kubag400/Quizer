using FluentResults;
using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Helpers;
using Server.Models;
using Server.Models.Requests;
using Server.Models.Responses;

namespace Server.Services
{
    public class SqliteQuizService(QuizzMeContext context, ILogger<SqliteQuizService> logger) : IQuizService
    {
        private ILogger<SqliteQuizService> _logger { get; } = logger;

        public Task<Result> AddQuestionToQuiz(AddQuestionToQuizzRequest request)
        {
            //_context.Add(request.);
            throw new NotImplementedException();
        }

        public async Task<Result> CreateQuiz(AddQuizRequest request)
        {
            context.Add(request.MapAddQuizzRequestToEntity());
            var save = await context.SaveChangesAsync();
            if (save > 0)
            {
                return Result.Ok();
            }
            return Result.Fail("Cannot add quizz");
        }

        public async Task<Result<List<GetQuizzesByTopicResponse>>> GetQuizzesByTopic(string topic)
        {
            var result = await context.Quizzes
                .Where(x => x.Topic == topic)
                .Include(x => x.Questions)
                .ToListAsync();
            return Result.Ok(result.MapToQuizzesByTopicResponse());
        }

        public async Task<Result<GetAllQuizzesResponse>> GetAllQuizzes()
        {
            var quizzes = await context.Quizzes.ToListAsync();
            return Result.Ok(quizzes.MapToGetAllQuizzesResponse());
        }

        public async Task<Result<GetQuizDetailsResponse>> GetQuizDetails(string id)
        {
            Guid.TryParse(id, out Guid guid);
            if (guid == Guid.Empty)
            {
                _logger.LogError("Cannot resolve guid:{}", id);
                return Result.Fail("Cannot resolve quizId");
            }
            
            var quiz = await context.Quizzes.Include(x => x.Questions).Where(x => x.QuizzId == guid).FirstOrDefaultAsync();

            if (quiz == null)
            {
                logger.LogError("Cannot find quiz {guid}", guid);
            }
            
            return Result.Ok(quiz!.MapToGetQuizDetailsResponse());
        }
    }
}
