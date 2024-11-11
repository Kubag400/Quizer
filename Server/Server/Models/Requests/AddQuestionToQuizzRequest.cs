namespace Server.Models.Requests
{
    public class AddQuestionToQuizzRequest
    {
        public required string QuizId { get; set; }
        public required string Description { get; set; }
        public required string CorrectAnswer { get; set; }
        public required string[] OtherAnswers { get; set; }
    }
}
