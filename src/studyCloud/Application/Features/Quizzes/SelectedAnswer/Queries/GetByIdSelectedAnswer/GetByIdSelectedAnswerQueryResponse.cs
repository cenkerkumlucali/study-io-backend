namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetByIdSelectedAnswer;

public class GetByIdSelectedAnswerQueryResponse
{
    public int Id { get; set; }
    public int UserEmail { get; set; }
    public int QuestionId { get; set; }
    public int PossibleAnswerId { get; set; }
    public int QuizHistoryId { get; set; }
}