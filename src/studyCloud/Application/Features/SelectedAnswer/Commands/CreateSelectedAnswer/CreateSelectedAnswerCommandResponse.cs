namespace Application.Features.SelectedAnswer.Commands.CreateSelectedAnswer;

public class CreateSelectedAnswerCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuestionId { get; set; }
    public long PossibleAnswerId { get; set; }
    public long QuizHistoryId { get; set; }
}