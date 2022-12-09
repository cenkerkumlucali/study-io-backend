namespace Application.Features.Follows.Queries.GetFollowings;

public class GetFollowingsQueryResponse
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
}