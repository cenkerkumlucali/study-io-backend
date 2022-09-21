using Core.Persistence.Repositories;

namespace Domain.Entities.Quizzes;

public class QuizHistory:Entity
{
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }

    public QuizHistory()
    {
    }

    public QuizHistory(int id, int userId, int quizId, DateTime quizDate) : this()
    {
        Id = id;
        UserId = userId;
        QuizId = quizId;
        QuizDate = quizDate;
    }
}