using MediatR;

namespace Application.Features.SelectedAnswer.Commands.DeleteSelectedAnswer;

public class DeleteSelectedAnswerCommandRequest:IRequest<DeleteSelectedAnswerCommandResponse>
{
    public long Id { get; set; }
    
}