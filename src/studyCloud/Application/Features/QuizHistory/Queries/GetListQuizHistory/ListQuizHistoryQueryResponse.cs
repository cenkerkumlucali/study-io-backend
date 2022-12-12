namespace Application.Features.QuizHistory.Queries.GetListQuizHistory;

public class ListQuizHistoryQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public long QuizId { get; set; }
    public DateTime QuizDate { get; set; }
}