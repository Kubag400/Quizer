using Server.Database.Entities;
using Server.Models;
using Server.Models.Responses;
using System.Runtime.CompilerServices;

namespace Server.Helpers
{
    public static class QuizzMaper
    {
        public static QuizzEntity MapAddQuizzRequestToEntity(this AddQuizzRequest request)
        {
            //TODO: tona validacji, testy
            var result = new QuizzEntity
            {
                QuizzId = Guid.NewGuid(),
                Questions = new(),
                Topic = request.Topic
            };

            for (int i = 0; i < request.Questions.Count; i++)
            {
                var a = new QuizzQuestionEntiity
                {
                    Id = Guid.NewGuid(),
                    CorrectAnswer = request.Questions[i].CorrectAnswer,
                    Description = request.Questions[i].Description,
                    Quizz = result,
                    
                    Answers = request.Questions[i].OtherAnswers
                };

                result.Questions.Add(a);
            }
            return result;
        }

        public static List<GetQuizzesByTopicResponse> MapToQuizzesByTopicResponse(this List<QuizzEntity> entity)
        {
            var response = new List<GetQuizzesByTopicResponse>();
            foreach (var item in entity)
            {
                if(item.Questions is not null)
                {
                    response.Add(new GetQuizzesByTopicResponse
                    {
                        QuizzId = item.QuizzId,
                        CountOfQuestions = item.Questions.Count,
                        Topic = item.Topic,
                    });
                }
            }
            return response;
        }
    }
}
