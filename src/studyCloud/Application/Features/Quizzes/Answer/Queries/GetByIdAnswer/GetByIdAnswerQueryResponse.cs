namespace Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQueryResponse
{
    public int Id { get; set; }
    public int Question{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}