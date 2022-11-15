namespace Application.Features.Quizzes.QuizHistory.Dtos;

public class UpdateQuizHistoryQueryResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}