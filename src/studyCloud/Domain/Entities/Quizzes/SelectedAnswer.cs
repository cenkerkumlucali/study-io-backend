using Core.Persistence.Repositories;

namespace Domain.Entities.Quizzes;

public class SelectedAnswer : Entity
{
    public int UserId { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }

    public SelectedAnswer()
    {
    }

    public SelectedAnswer(int id, int questionId, int possibleAnswerId,int quizHistoryId) : this()
    {
        QuizHistoryId = quizHistoryId;
        Id = id;
        QuestionId = questionId;
        PossibleAnswerId = possibleAnswerId;
    }
}