using MediatR;

namespace Application.Features.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQueryRequest : IRequest<GetByIdQuestionQueryResponse>
{
    public long Id { get; set; }
    
}