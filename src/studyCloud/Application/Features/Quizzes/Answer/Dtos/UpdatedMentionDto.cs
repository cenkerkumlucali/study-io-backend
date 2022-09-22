using Domain.Enums;

namespace Application.Features.Quizzes.Answer.Dtos;

public class UpdatedAnswerDto
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}