using FluentResults;
using Server.Models;
using Server.Models.Responses;

namespace Server.Services
{
    public interface IQuizzService
    {
        Task<Result> CreateQuizz(AddQuizzRequest request);
        Task<Result> AddQuestionToQuizz(AddQuestionToQuizzRequest request);
        Task<Result<List<GetQuizzesByTopicResponse>>> GetQuizzesByTopic(string topic);
    }
}
