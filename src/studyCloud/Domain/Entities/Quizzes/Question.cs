using Core.Persistence.Repositories;

namespace Domain.Entities.Quizzes;

public class Question : Entity
{
    public int QuizId { get; set; }
    public string Text { get; set; }
    public List<Answer> Answers { get; set; }

    public Question()
    {
    }

    public Question(int id, int quizId, string question, List<Answer> answers) : this()
    {
        Id = Id;
        QuizId = quizId;
        Text = question;
        Answers = answers;
    }
}