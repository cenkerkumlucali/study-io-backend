namespace Application.Features.Feeds.PostLike.Queries.GetMembersLikedPost;

public class GetMembersLikedPostQueryResponse
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
}