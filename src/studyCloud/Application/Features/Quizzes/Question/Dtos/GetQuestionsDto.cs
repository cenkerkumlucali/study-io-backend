using Application.Features.Quizzes.Answer.Dtos;

namespace Application.Features.Quizzes.Question.Dtos;

public class GetQuestionsDto
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public List<AnswerDto> Answers { get; set; }
}