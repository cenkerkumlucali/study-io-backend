using Application.Features.Feeds.Post.Dtos;

namespace Application.Features.Users.User.Queries.Profile;

public class ProfileQueryResponse
{
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string PictureUrl { get; set; }
    public bool IsFollowing { get; set; }
    public bool IsFollower { get; set; }
    public bool IsBlocking { get; set; }
    public bool IsBlocked { get; set; }
    public string Introduce { get; set; }
    public int PostsCount { get; set; }
    public long FollowersCount { get; set; }
    public long FollowingsCount { get; set; }
    public IList<PostListDto> Posts { get; set; }
    public bool IsMe { get; set; }
}