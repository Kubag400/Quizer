namespace Server.Models
{
    public class AddQuestionRequest
    {
        public required string Description { get; set; }
        public required string CorrectAnswer { get; set; }
        public required List<string> OtherAnswers { get; set; }
    }
}
