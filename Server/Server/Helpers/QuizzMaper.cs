using Server.Database.Entities;
using Server.Models;
using Server.Models.Responses;

namespace Server.Helpers
{
    public static class QuizzMaper
    {
        public static QuizzEntity MapAddQuizzRequestToEntity(this AddQuizRequest request)
        {
            //TODO: tona validacji, testy
            var result = new QuizzEntity
            {
                QuizzId = Guid.NewGuid(),
                Questions = new(),
                Topic = request.Topic,
                QuizName = request.QuizName
            };

            for (int i = 0; i < request.Questions.Count; i++)
            {
                var quiz = new QuizQuestionEntity
                {
                    Id = Guid.NewGuid(),
                    CorrectAnswer = request.Questions[i].CorrectAnswer,
                    Description = request.Questions[i].Description,
                    Quizz = result,

                    Answers = request.Questions[i].OtherAnswers
                };
                quiz.Answers.Add(quiz.CorrectAnswer);
                result.Questions.Add(quiz);
            }

            return result;
        }

        public static List<GetQuizzesByTopicResponse> MapToQuizzesByTopicResponse(this List<QuizzEntity> entity)
        {
            var response = new List<GetQuizzesByTopicResponse>();
            foreach (var item in entity)
            {
                if (item.Questions is not null)
                {
                    response.Add(new GetQuizzesByTopicResponse
                    {
                        QuizId = item.QuizzId,
                        CountOfQuestions = item.Questions.Count,
                        Topic = item.Topic,
                    });
                }
            }

            return response;
        }

        public static GetAllQuizzesResponse MapToGetAllQuizzesResponse(this List<QuizzEntity> entity)
        {
            var response = new GetAllQuizzesResponse();

            foreach (var item in entity)
            {
                response.Quizzes.Add(new(item.QuizzId, item.Topic, item.QuizName));
            }

            return response;
        }

        public static GetQuizDetailsResponse MapToGetQuizDetailsResponse(this QuizzEntity entity)
        {
            var response = new GetQuizDetailsResponse
            {
                QuizName = entity.QuizName,
                Topic = entity.Topic
            };
            foreach (var item in entity.Questions)
            {
                response.Questions.Add(new()
                {
                    Description = item.Description,
                    CorrectAnswer = item.CorrectAnswer,
                    Answers = item.Answers,
                });
            }

            return response;
        }
    }
}