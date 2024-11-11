namespace Server.Database.Entities
{
    public class QuizzEntity
    {
        public Guid QuizzId { get; set; }
        public string Topic { get; set; }
        public string QuizName { get; set; }
        public List<QuizQuestionEntity> Questions { get; set; }
    }
}
