namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryResponse
{
    public long Id { get; set; }
    public long UserEmail { get; set; }
    public long QuestionId { get; set; }
    public long PossibleAnswerId { get; set; }
    public long QuizHistoryId { get; set; }
}