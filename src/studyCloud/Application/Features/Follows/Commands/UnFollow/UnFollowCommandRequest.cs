using MediatR;

namespace Application.Features.Follows.Commands.UnFollow;

public class UnFollowCommandRequest:IRequest<UnFollowCommandResponse>
{
    public long FollowerId { get; set; }
    public long? FollowingId { get; set; }
}