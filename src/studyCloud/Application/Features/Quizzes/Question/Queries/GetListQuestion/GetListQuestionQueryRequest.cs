using Application.Features.Quizzes.Question.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetListQuestion;

public class GetListQuestionQueryRequest : IRequest<QuestionListModel>
{
    public PageRequest PageRequest { get; set; }

}