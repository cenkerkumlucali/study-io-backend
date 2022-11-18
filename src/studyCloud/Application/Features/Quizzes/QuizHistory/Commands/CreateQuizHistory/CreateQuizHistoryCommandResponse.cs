namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}