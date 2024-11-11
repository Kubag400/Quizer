using Server.Models.Requests;

namespace Server.Models
{
    public class AddQuizRequest
    {
        public required string QuizName { get; set; }
        public required string Topic { get; set; }
        public required List<AddQuestionRequest> Questions { get; set; }
    }
}
