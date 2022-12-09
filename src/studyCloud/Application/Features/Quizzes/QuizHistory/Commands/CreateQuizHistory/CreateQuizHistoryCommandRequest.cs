using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandRequest : IRequest<CreateQuizHistoryCommandResponse>
{
    public long UserId { get; set; }
    public long QuizId { get; set; }
}