using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UnLikeComment;

public class UnLikeCommentCommandRequest:IRequest<UnLikeCommentCommandResponse>
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
}