namespace Application.Features.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQueryResponse
{
    public long Id { get; set; }
    public long Question{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}