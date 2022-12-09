using Domain.Entities.Common;
using Domain.Entities.Users;


namespace Domain.Entities.Quizzes;

public class SelectedAnswer : BaseEntity
{
    public long UserId { get; set; }
    public long QuestionId { get; set; }
    public long AnswerId { get; set; }
    public long QuizHistoryId { get; set; }

    public virtual User User { get; set; }
    public virtual Question Question { get; set; }
    public virtual Answer Answer { get; set; }
    public virtual QuizHistory QuizHistory { get; set; }

}