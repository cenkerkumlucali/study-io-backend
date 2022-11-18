namespace Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public int QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}