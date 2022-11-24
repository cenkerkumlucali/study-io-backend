using MediatR;

namespace Application.Features.Users.Block.Commands.CreateBlock;

public class CreateBlockCommandRequest:IRequest<CreateBlockCommandResponse>
{
    public int AgentId { get; set; }
    public int TargetId { get; set; }
}