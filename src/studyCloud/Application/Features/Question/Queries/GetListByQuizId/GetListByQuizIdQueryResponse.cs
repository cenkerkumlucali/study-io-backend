using Application.Features.Answer.Dtos;

namespace Application.Features.Question.Queries.GetListByQuizId;

public class GetListByQuizIdQueryResponse
{
    public long Id { get; set; }
    public string ImageUrl { get; set; }
    public List<AnswerDto> Answers { get; set; }
}