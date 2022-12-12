using Application.Features.Answer.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Answer.Queries.GetListAnswer;

public class GetListAnswerQueryRequest : IRequest<AnswerListModel>
{
    public PageRequest PageRequest { get; set; }
}