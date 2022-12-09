namespace Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public long QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}