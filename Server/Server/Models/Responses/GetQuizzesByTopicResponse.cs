namespace Server.Models.Responses
{
    public class GetQuizzesByTopicResponse
    {
        public Guid QuizzId { get; set; }
        public string Topic { get; set; }
        public int CountOfQuestions { get; set; }
    }
}