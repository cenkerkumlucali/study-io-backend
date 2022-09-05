using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Answer:Entity
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    public Answer()
    {
        
    }

    public Answer(int id, string text, int questionId, bool isCorrect) : this()
    {
        Id = id;
        Text = text;
        QuestionId = questionId;
        IsCorrect = isCorrect;
    }
}