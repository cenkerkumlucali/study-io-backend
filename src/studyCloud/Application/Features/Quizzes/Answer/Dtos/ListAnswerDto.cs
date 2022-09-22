using Domain.Enums;

namespace Application.Features.Quizzes.Answer.Dtos;

public class ListAnswerDto
{
    public int Id { get; set; }
    public int Question{ get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
}