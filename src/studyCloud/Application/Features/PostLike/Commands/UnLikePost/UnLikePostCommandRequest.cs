using MediatR;

namespace Application.Features.PostLike.Commands.UnLikePost;

public class UnLikePostCommandRequest:IRequest<UnLikePostCommandResponse>
{
   public long UserId { get; set; }
   public long PostId { get; set; }
}