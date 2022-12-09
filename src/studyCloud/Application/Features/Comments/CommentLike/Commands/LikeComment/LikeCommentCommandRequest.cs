using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.LikeComment;

public class LikeCommentCommandRequest:IRequest<LikeCommentCommandResponse>
{
    public long UserId { get; set; }
    public long CommentId { get; set; }
}