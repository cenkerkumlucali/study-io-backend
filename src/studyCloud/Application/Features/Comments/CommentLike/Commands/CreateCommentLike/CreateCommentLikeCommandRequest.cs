using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.CreateCommentLike;

public class CreateCommentLikeCommandRequest:IRequest<CreateCommentLikeCommandResponse>
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
}