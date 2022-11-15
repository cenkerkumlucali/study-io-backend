using Application.Features.Comments.CommentLike.Dtos;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;

public class DeleteCommentLikeCommandRequest:IRequest<DeleteCommentLikeCommandResponse>
{
    public int Id { get; set; }
}