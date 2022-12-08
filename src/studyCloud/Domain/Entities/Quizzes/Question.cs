using Domain.Enums;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Question : BaseEntity
{
    public int QuizId { get; set; }
    public Difficulty Difficulty { get; set; }
    public virtual Quiz Quiz { get; set; }
    public virtual List<Answer> Answers { get; set; }
    public virtual ICollection<QuestionImage>? QuestionImages { get; set; }
}