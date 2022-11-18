using MediatR;

namespace Application.Features.Quizzes.Answer.Commands.DeleteAnswer;

public class DeleteAnswerCommandRequest:IRequest<DeleteAnswerCommandResponse>
{
    public int Id { get; set; }
    
}