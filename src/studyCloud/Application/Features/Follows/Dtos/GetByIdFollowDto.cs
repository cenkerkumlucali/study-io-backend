namespace Application.Features.Follows.Dtos;

public class GetByIdFollowDto
{
    public int Id { get; set; }
    public string FollowerUserName { get; set; }
    public string FollowingIdUserName { get; set; }
}