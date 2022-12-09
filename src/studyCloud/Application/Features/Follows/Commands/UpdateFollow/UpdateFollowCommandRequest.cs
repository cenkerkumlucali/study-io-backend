using MediatR;

namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommandRequest : IRequest<UpdateFollowCommandResponse>
{
    public long Id { get; set; }
    public long FollowerId { get; set; }
    public long FollowingId { get; set; }

    
}