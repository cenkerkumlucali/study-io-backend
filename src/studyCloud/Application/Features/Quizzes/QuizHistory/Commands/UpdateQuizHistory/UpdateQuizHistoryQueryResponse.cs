namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryQueryResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}