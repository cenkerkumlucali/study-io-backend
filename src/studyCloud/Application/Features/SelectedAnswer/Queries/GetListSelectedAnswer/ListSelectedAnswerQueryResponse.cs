namespace Application.Features.SelectedAnswer.Queries.GetListSelectedAnswer;

public class ListSelectedAnswerQueryResponse
{
    public long Id { get; set; }
    public string UserEmail { get; set; }
    public string Question { get; set; }
    public string PossibleAnswer { get; set; }
    public long QuizHistoryId { get; set; }
}