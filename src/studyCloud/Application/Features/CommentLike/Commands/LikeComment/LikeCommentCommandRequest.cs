using MediatR;

namespace Application.Features.CommentLike.Commands.LikeComment;

public class LikeCommentCommandRequest:IRequest<LikeCommentCommandResponse>
{
    public long UserId { get; set; }
    public long CommentId { get; set; }
}