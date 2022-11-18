namespace Application.Features.Feeds.PostLike.Commands.CreatePostLike;

public class CreatePostLikeCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}