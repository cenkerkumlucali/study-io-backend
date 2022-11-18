namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandResponse
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    public DateTime CreatedDate { get; set; }
}