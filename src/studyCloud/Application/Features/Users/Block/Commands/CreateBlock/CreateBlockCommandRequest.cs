using MediatR;

namespace Application.Features.Users.Block.Commands.CreateBlock;

public class CreateBlockCommandRequest:IRequest<CreateBlockCommandResponse>
{
    public long AgentId { get; set; }
    public long TargetId { get; set; }
}