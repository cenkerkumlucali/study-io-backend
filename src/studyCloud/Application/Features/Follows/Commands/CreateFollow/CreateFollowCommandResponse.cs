namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandResponse
{
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
}