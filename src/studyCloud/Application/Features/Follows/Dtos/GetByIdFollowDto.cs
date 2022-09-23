namespace Application.Features.Follows.Dtos;

public class GetByIdFollowDto
{
    public int Id { get; set; }
    public string FollowerEmail { get; set; }
    public string FollowingIdEmail { get; set; }
}