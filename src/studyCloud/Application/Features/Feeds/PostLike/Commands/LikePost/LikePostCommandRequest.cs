using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.LikePost;

public class LikePostCommandRequest:IRequest<LikePostCommandResponse>
{
    public long UserId { get; set; }
    public long PostId { get; set; }
}