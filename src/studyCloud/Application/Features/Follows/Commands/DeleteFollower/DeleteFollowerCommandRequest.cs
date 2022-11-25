using Application.Features.Follows.Commands.UnFollow;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollower;

public class DeleteFollowerCommandRequest:IRequest<DeleteFollowerCommandResponse>
{
    public int FollowerId { get; set; }
    public int? FollowingId { get; set; }
}