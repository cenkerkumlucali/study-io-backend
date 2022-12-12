namespace Application.Features.SelectedAnswer.Commands.UpdateSelectedAnswer;

public class UpdateSelectedAnswerCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuestionId { get; set; }
    public long PossibleAnswerId { get; set; }
    public long QuizHistoryId { get; set; }
}