using MediatR;

namespace Application.Features.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQueryRequest : IRequest<GetByIdQuizHistoryQueryResponse>
{
    public long Id { get; set; }
    
}