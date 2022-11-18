using MediatR;

namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommandRequest : IRequest<UpdateFollowCommandResponse>
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

    
}