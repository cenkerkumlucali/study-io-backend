using MediatR;

namespace Application.Features.Quiz.Queries.GetByIdQuiz;

public class GetByIdQuizQueryRequest:IRequest<GetByIdQuizQueryResponse>
{
    public long Id { get; set; }
   
}