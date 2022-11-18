namespace Application.Features.Quizzes.Answer.Commands.CreateAnswer;

public class CreateAnswerCommandResponse
{
    public int Id { get; set; }
    public int QuestionId{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}