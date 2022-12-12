using Application.Features.Question.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Question.Queries.GetListByQuizId;

public class GetListByQuizIdQueryRequest:IRequest<GetByQuizIdModel>
{
    public PageRequest PageRequest { get; set; }
    public long QuizId { get; set; }
}