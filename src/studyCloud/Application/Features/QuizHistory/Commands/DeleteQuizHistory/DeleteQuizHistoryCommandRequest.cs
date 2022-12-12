using MediatR;

namespace Application.Features.QuizHistory.Commands.DeleteQuizHistory;

public class DeleteQuizHistoryCommandRequest:IRequest<DeleteQuizHistoryCommandResponse>
{
    public long Id { get; set; }
    
}