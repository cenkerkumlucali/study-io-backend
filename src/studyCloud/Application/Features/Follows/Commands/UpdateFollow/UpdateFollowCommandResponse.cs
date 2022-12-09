namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommandResponse
{
    public long Id { get; set; }
    public long FollowerId { get; set; }
    public long FollowingId { get; set; }
    public DateTime CreatedDate { get; set; }
}