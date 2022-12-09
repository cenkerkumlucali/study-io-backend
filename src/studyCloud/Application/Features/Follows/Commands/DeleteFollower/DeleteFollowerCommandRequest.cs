using Application.Features.Follows.Commands.UnFollow;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollower;

public class DeleteFollowerCommandRequest:IRequest<DeleteFollowerCommandResponse>
{
    public long FollowerId { get; set; }
    public long? FollowingId { get; set; }
}