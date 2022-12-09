namespace Application.Features.Follows.Commands.DeleteFollower;

public class DeleteFollowerCommandResponse
{
    public long? FollowerId { get; set; }
    public long? FollowingId { get; set; }
}