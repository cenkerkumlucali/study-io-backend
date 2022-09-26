using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Quizzes;

public class QuizHistory:Entity
{
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
    public virtual User User { get; set; }
    public virtual Quiz Quiz { get; set; }

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