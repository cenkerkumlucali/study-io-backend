namespace Application.Features.Quizzes.Answer.Queries.GetListAnswer;

public class ListAnswerQueryResponse
{
    public long Id { get; set; }
    public string QuestionUrl { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}