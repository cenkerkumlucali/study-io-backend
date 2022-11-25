using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.LikePost;

public class LikePostCommandRequest:IRequest<LikePostCommandResponse>
{
    public int UserId { get; set; }
    public int PostId { get; set; }
}