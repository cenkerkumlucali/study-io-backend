using Domain.Entities.Common;
using Domain.Entities.Users;

namespace Domain.Entities.Quizzes;

public class QuizHistory:BaseEntity
{
    public long UserId { get; set; }
    public long QuizId { get; set; }
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