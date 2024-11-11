using FluentResults;
using Server.Models;
using Server.Models.Requests;
using Server.Models.Responses;

namespace Server.Services
{
    public interface IQuizService
    {
        Task<Result> CreateQuiz(AddQuizRequest request);
        Task<Result> AddQuestionToQuiz(AddQuestionToQuizzRequest request);
        Task<Result<List<GetQuizzesByTopicResponse>>> GetQuizzesByTopic(string topic);
        Task<Result<GetAllQuizzesResponse>> GetAllQuizzes();
        Task<Result<GetQuizDetailsResponse>> GetQuizDetails(string id);
    }
}
