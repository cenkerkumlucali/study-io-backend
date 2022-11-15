using Application.Features.Quizzes.QuizHistory.Dtos;
using MediatR;

namespace Application.Features.Quizzes.QuizHistory.Commands.DeleteQuizHistory;

public class DeleteQuizHistoryCommandRequest:IRequest<DeleteQuizHistoryCommandResponse>
{
    public int Id { get; set; }
    
}