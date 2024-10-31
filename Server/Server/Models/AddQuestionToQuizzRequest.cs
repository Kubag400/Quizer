namespace Server.Models
{
    public class AddQuestionToQuizzRequest
    {
        public required string QuizzId { get; set; }
        public required string Description { get; set; }
        public required string CorrectAnswer { get; set; }
        public required string[] OtherAnswers { get; set; }
    }
}
