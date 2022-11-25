namespace Application.Features.Follows.Commands.DeleteFollower;

public class DeleteFollowerCommandResponse
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
}