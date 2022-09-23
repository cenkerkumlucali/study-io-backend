using Core.Persistence.Repositories;
using Domain.Enums;

namespace Domain.Entities.Quizzes;

public class Question : Entity
{
    public int QuizId { get; set; }
    public string Text { get; set; }
    public Difficulty Difficulty { get; set; }
    public Quiz Quiz { get; set; }
    public List<Answer> Answers { get; set; }

    public Question()
    {
    }

    public Question(int id, int quizId, string question, List<Answer> answers, Difficulty difficulty) : this()
    {
        Id = id;
        QuizId = quizId;
        Text = question;
        Answers = answers;
        Difficulty = difficulty;
    }
}