using MediatR;

namespace Application.Features.Quizzes.Answer.Queries.GetByIdAnswer;

public class GetByIdAnswerQueryRequest:IRequest<GetByIdAnswerQueryResponse>
{
    public long Id { get; set; }
  
}