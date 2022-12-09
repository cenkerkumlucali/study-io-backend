namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}