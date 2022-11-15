using Application.Features.Quizzes.SelectedAnswer.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.SelectedAnswer.Queries.GetListSelectedAnswer;

public class GetListSelectedAnswerQueryRequest : IRequest<SelectedAnswerListModel>
{
    public PageRequest PageRequest { get; set; }

  
}