namespace Application.Features.Feeds.PostLike.Dtos;

public class UpdatePostLikeCommandResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}