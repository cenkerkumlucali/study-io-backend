using Core.Persistence.Repositories;

namespace Domain.Entities.Quizzes;

public class Answer:Entity
{
    public int QuestionId{ get; set; }
    public virtual Question Question{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Answer()
    {
        
    }

    public Answer(int id, string text, Question question, bool isCorrect) : this()
    {
        Id = id;
        Text = text;
        Question = question;
        IsCorrect = isCorrect;
    }
}