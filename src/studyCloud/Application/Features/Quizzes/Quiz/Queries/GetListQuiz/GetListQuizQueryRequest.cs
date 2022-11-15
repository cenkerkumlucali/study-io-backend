using Application.Features.Quizzes.Quiz.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetListQuiz;

public class GetListQuizQueryRequest : IRequest<QuizListModel>
{
    public PageRequest PageRequest { get; set; }

    
}