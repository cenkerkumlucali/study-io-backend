namespace Application.Features.Answer.Dtos;

public class AnswerDto
{
    public long questionId { get; set; }
    public string? content { get; set; }
    public bool isCorrect { get; set; }
}