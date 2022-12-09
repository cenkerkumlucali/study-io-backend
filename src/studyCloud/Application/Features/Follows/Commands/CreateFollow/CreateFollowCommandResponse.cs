namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandResponse
{
    public long FollowerId { get; set; }
    public long FollowingId { get; set; }
}