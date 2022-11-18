using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;

public class UpdateCommentLikeCommandRequest : IRequest<UpdateCommentLikeCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CommentId { get; set; }
}