namespace Application.Features.Follows.Dtos;

public class ListFollowDto
{
    public int Id { get; set; }
    public string FollowerUserName { get; set; }
    public string FollowingIdUserName { get; set; }
}