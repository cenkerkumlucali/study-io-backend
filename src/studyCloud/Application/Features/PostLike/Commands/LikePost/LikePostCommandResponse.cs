namespace Application.Features.PostLike.Commands.LikePost;

public class LikePostCommandResponse
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PostId { get; set; }
}