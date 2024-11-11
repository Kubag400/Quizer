namespace Server.Models.Responses
{
    public class GetQuizzesByTopicResponse
    {
        public Guid QuizId { get; set; }
        public string Topic { get; set; }
        public int CountOfQuestions { get; set; }
    }
}