using Application.Features.Quiz.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quiz.Queries.GetListQuiz;

public class GetListQuizQueryRequest : IRequest<QuizListModel>
{
    public PageRequest PageRequest { get; set; }

    
}