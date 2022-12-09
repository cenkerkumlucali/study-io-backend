using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryCommandRequest : IRequest<UpdateQuizHistoryQueryResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long QuizId { get; set; }

   
}