namespace Application.Features.Follows.Dtos;

public class ListFollowDto
{
    public int Id { get; set; }
    public string FollowerEmail { get; set; }
    public string FollowingIdEmail { get; set; }
}