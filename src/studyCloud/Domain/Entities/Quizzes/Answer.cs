using System.ComponentModel.DataAnnotations.Schema;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Answer:BaseEntity
{
    public int QuestionId{ get; set; }
    public virtual Question Question{ get; set; }
    public string Content { get; set; }
    public bool IsCorrect { get; set; }
    [NotMapped]
    public override DateTime UpdatedDate { get; set; }

    public Answer()
    {
        
    }

    public Answer(int id, string text, Question question, bool isCorrect) : this()
    {
        Id = id;
        Content = text;
        Question = question;
        IsCorrect = isCorrect;
    }
}