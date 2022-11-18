using MediatR;

namespace Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQueryRequest:IRequest<GetByIdAnswerQueryResponse>
{
    public int Id { get; set; }
  
}