namespace Application.Features.Quizzes.Answer.Dtos;

public class UpdatedAnswerCommandResponse
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}