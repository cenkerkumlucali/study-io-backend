using MediatR;

namespace Application.Features.Follows.Commands.UnFollow;

public class UnFollowCommandRequest:IRequest<UnFollowCommandResponse>
{
    public int FollowerId { get; set; }
    public int? FollowingId { get; set; }
}