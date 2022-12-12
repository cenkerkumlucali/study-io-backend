using Application.Features.SelectedAnswer.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.SelectedAnswer.Queries.GetListSelectedAnswer;

public class GetListSelectedAnswerQueryRequest : IRequest<SelectedAnswerListModel>
{
    public PageRequest PageRequest { get; set; }

  
}