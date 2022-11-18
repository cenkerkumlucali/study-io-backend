using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.UpdateQuizHistory;

public class UpdateQuizHistoryCommandRequest : IRequest<UpdateQuizHistoryQueryResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int QuizId { get; set; }

   
}