using Server.Models.Requests;

namespace Server.Models.Responses;

public class GetAllQuizzesResponse
{
    public GetAllQuizzesResponse()
    {
        Quizzes = new();
    }
    public List<QuizViewModel> Quizzes { get; set; }
}