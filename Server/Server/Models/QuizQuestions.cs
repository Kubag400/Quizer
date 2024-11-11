namespace Server.Models;

public class QuizQuestions
{
    public required string Description { get; set; }
    public required string CorrectAnswer { get; set; }
    public List<string> Answers { get; set; }
}