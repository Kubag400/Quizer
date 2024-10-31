namespace Server.Models
{
    public class AddQuizzRequest
    {
        public required string QuizzName { get; set; }
        public required string Topic { get; set; }
        public required List<AddQuestionRequest> Questions { get; set; }
    }
}
