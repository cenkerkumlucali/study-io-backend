using MediatR;

namespace Application.Features.Answer.Commands.DeleteAnswer;

public class DeleteAnswerCommandRequest:IRequest<DeleteAnswerCommandResponse>
{
    public long Id { get; set; }
    
}