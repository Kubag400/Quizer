namespace Server.Database.Entities
{
    public class QuizzEntity
    {
        public Guid QuizzId { get; set; }
        public required List<QuizzQuestionEntiity> Questions { get; set; }
    }
}
