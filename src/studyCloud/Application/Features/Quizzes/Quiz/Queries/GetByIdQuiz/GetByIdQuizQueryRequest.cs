using MediatR;

namespace Application.Features.Quizzes.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQueryRequest:IRequest<GetByIdQuizQueryResponse>
{
    public long Id { get; set; }
   
}