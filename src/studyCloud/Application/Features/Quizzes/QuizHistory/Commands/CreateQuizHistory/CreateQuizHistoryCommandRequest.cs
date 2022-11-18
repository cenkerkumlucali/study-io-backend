using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandRequest : IRequest<CreateQuizHistoryCommandResponse>
{
    public int UserId { get; set; }
    public int QuizId { get; set; }

    
}