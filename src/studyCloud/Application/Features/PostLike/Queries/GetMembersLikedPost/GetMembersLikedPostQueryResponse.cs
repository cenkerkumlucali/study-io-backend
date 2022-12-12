namespace Application.Features.PostLike.Queries.GetMembersLikedPost;

public class GetMembersLikedPostQueryResponse
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
}