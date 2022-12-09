using MediatR;

namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandRequest:IRequest<CreateFollowCommandResponse>
{
    public long? FollowerId { get; set; }
    public long? FollowingId { get; set; }
}