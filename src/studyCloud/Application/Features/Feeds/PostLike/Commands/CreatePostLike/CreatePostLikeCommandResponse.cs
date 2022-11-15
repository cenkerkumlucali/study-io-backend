namespace Application.Features.Feeds.PostLike.Dtos;

public class CreatePostLikeCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}