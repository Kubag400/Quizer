using FluentResults;
using Microsoft.EntityFrameworkCore;
using Server.Database;
using Server.Database.Entities;
using Server.Helpers;
using Server.Models;
using Server.Models.Responses;

namespace Server.Services
{
    public class SqliteQuizzService : IQuizzService
    {
        private readonly QuizzMeContext _context;
        public SqliteQuizzService(QuizzMeContext context)
        {
            _context = context;
        }
        public Task<Result> AddQuestionToQuizz(AddQuestionToQuizzRequest request)
        {
            //_context.Add(request.);
            throw new NotImplementedException();
        }

        public async Task<Result> CreateQuizz(AddQuizzRequest request)
        {
            _context.Add(request.MapAddQuizzRequestToEntity());
            var save = await _context.SaveChangesAsync();
            if (save > 0)
            {
                return Result.Ok();
            }
            return Result.Fail("Cannot add quizz");
        }

        public async Task<Result<List<GetQuizzesByTopicResponse>>> GetQuizzesByTopic(string topic)
        {
            var result = await _context.Quizzes
                .Where(x => x.Topic == topic)
                .Include(x => x.Questions)
                .ToListAsync();
            return Result.Ok(result.MapToQuizzesByTopicResponse());
        }
    }
}
