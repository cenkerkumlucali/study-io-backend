using Application.Features.Quizzes.Quiz.Dtos;
using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQueryRequest:IRequest<GetByIdQuizQueryResponse>
{
    public int Id { get; set; }
   
}