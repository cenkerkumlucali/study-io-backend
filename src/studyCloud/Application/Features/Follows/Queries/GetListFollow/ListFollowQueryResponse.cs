namespace Application.Features.Follows.Queries.GetListFollow;

public class ListFollowQueryResponse
{
    public long Id { get; set; }
    public string FollowerEmail { get; set; }
    public string FollowingIdEmail { get; set; }
}