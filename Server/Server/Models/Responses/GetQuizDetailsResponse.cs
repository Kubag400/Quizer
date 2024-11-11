namespace Server.Models.Responses;

public class GetQuizDetailsResponse
{
    public string Topic { get; set; }
    public string QuizName { get; set; }
    public List<QuizQuestions> Questions { get; set; } = new();
}