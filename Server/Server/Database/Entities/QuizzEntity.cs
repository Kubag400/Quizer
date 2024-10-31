namespace Server.Database.Entities
{
    public class QuizzEntity
    {
        public Guid QuizzId { get; set; }
        public string Topic { get; set; }
        public List<QuizzQuestionEntiity> Questions { get; set; }
    }
}
