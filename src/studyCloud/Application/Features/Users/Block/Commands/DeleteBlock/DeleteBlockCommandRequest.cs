using MediatR;

namespace Application.Features.Users.Block.Commands.DeleteBlock;

public class DeleteBlockCommandRequest:IRequest<DeleteBlockCommandResponse>
{
    public long AgentId { get; set; }
    public long TargetId { get; set; }
}