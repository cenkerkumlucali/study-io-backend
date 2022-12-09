using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.DeleteQuizHistory;

public class DeleteQuizHistoryCommandRequest:IRequest<DeleteQuizHistoryCommandResponse>
{
    public long Id { get; set; }
    
}