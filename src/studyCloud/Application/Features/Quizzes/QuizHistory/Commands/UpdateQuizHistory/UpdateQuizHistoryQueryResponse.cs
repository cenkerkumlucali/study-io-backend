namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryQueryResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}