using MediatR;

namespace Application.Features.Quizzes.Question.Queries.GetByIdQuestion;

public class GetByIdQuestionQueryRequest : IRequest<GetByIdQuestionQueryResponse>
{
    public long Id { get; set; }
    
}