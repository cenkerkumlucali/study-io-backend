namespace Application.Features.Answer.Commands.CreateAnswer;

public class CreateAnswerCommandResponse
{
    public long Id { get; set; }
    public long QuestionId{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}