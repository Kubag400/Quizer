namespace Server.Database.Entities
{
    public class QuizQuestionEntity
    {
        public QuizzEntity Quizz { get; set; }
        public required Guid Id { get; set; }
        public required string Description { get; set; }
        public required string CorrectAnswer { get; set; }
        public List<string> Answers { get; set; }
    }
}
