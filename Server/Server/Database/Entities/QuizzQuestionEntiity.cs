namespace Server.Database.Entities
{
    public class QuizzQuestionEntiity
    {
        public required QuizzEntity Quizz { get; set; }
        public required int Id { get; set; }
        public required string CorrectAnswer { get; set; }
        public required string Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
    }
}
