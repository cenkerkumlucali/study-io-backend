using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.LikeComment;

public class LikeCommentCommandRequest:IRequest<LikeCommentCommandResponse>
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
}