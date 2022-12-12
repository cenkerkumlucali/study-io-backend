using Application.Features.Question.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Question.Queries.GetListQuestion;

public class GetListQuestionQueryRequest : IRequest<QuestionListModel>
{
    public PageRequest PageRequest { get; set; }

}