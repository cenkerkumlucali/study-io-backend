using Application.Features.Quizzes.Question.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetListByQuizId;

public class GetListByQuizIdQueryRequest:IRequest<GetByQuizIdModel>
{
    public PageRequest PageRequest { get; set; }
    public long QuizId { get; set; }
}