using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UnLikeComment;

public class UnLikeCommentCommandRequest:IRequest<UnLikeCommentCommandResponse>
{
    public long UserId { get; set; }
    public long CommentId { get; set; }
}