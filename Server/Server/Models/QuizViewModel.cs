namespace Server.Models.Requests;

public class QuizViewModel
{
    public QuizViewModel(Guid id, string topic, string quizName)
    {
        Id = id;
        Topic = topic;
        QuizName = quizName;
    }
    public Guid Id { get; set; }
    public string Topic { get; set; }
    public string QuizName { get; set; }
}