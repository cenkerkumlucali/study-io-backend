using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Question:Entity
{
    
    public int QuizId { get; set; }
    public string Text { get; set; }
    
    public int AnswerId { get; set; }
    public List<Answer> Answers { get; set; }

    public Question()
    {
        
    }

    public Question(int quizId, string question, List<Answer> answers,  Category category,
        SubCategory subCategory) : this()
    {
        QuizId = quizId;
        Text = question;
        Answers = answers;
        
    }
}