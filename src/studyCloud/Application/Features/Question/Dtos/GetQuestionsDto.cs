using Application.Features.Answer.Dtos;

namespace Application.Features.Question.Dtos;

public class GetQuestionsDto
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public List<AnswerDto> Answers { get; set; }
}