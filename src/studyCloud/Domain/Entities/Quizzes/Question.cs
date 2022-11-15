using Domain.Enums;
using BaseEntity = Domain.Entities.Common.BaseEntity;

namespace Domain.Entities.Quizzes;

public class Question : BaseEntity
{
    public int QuizId { get; set; }
    public string Text { get; set; }
    public Difficulty Difficulty { get; set; }
    public virtual Quiz Quiz { get; set; }
    public virtual List<Answer> Answers { get; set; }


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