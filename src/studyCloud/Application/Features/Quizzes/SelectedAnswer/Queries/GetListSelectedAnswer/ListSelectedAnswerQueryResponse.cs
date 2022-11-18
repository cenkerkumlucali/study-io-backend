namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetListSelectedAnswer;

public class ListSelectedAnswerQueryResponse
{
    public int Id { get; set; }
    public string UserEmail { get; set; }
    public string Question { get; set; }
    public string PossibleAnswer { get; set; }
    public int QuizHistoryId { get; set; }
}