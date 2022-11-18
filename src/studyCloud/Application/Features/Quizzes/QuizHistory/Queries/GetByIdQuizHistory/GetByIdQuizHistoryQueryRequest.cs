using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Queries.GetByIdQuizHistory;

public class GetByIdQuizHistoryQueryRequest : IRequest<GetByIdQuizHistoryQueryResponse>
{
    public int Id { get; set; }
    
}