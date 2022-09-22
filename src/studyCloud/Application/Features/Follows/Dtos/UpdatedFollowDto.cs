namespace Application.Features.Follows.Dtos;

public class UpdatedFollowDto
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }
    public DateTime CreatedDate { get; set; }
}