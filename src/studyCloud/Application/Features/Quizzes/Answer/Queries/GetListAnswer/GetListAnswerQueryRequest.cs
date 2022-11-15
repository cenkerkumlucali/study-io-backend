using Application.Features.Quizzes.Answer.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.Answer.Queries.GetListAnswer;

public class GetListAnswerQueryRequest : IRequest<AnswerListModel>
{
    public PageRequest PageRequest { get; set; }
}