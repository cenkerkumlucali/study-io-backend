using Domain.Entities.Common;
using Domain.Entities.Users;


namespace Domain.Entities.Quizzes;

public class SelectedAnswer : BaseEntity
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int QuizHistoryId { get; set; }

    public virtual User User { get; set; }
    public virtual Question Question { get; set; }
    public virtual Answer Answer { get; set; }
    public virtual QuizHistory QuizHistory { get; set; }

    public SelectedAnswer()
    {
    }

    public SelectedAnswer(int id, int questionId, int possibleAnswerId, int quizHistoryId) : this()
    {
        QuizHistoryId = quizHistoryId;
        Id = id;
        QuestionId = questionId;
        AnswerId = possibleAnswerId;
    }
}