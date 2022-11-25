using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UnLikePost;

public class UnLikePostCommandRequest:IRequest<UnLikePostCommandResponse>
{
   public int UserId { get; set; }
   public int PostId { get; set; }
}