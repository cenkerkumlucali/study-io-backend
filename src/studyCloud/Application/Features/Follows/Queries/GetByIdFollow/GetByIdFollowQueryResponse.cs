namespace Application.Features.Follows.Dtos;

public class GetByIdFollowQueryResponse
{
    public int Id { get; set; }
    public string FollowerEmail { get; set; }
    public string FollowingIdEmail { get; set; }
}