namespace Application.Features.Quizzes.Answer.Queries.GetListAnswer;

public class ListAnswerQueryResponse
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}