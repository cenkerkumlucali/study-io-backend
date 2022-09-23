namespace Application.Features.Quizzes.QuizHistory.Dtos;

public class GetByIdQuizHistoryDto
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}