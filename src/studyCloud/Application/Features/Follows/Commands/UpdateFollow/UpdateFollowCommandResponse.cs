namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommandResponse
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    public DateTime CreatedDate { get; set; }
}