using MediatR;

namespace Application.Features.Users.Block.Commands.DeleteBlock;

public class DeleteBlockCommandRequest:IRequest<DeleteBlockCommandResponse>
{
    public int AgentId { get; set; }
    public int TargetId { get; set; }
}