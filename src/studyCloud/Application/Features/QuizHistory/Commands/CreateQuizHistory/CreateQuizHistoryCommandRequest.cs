using MediatR;

namespace Application.Features.QuizHistory.Commands.CreateQuizHistory;

public class CreateQuizHistoryCommandRequest : IRequest<CreateQuizHistoryCommandResponse>
{
    public long UserId { get; set; }
    public long QuizId { get; set; }
}