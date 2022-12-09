using MediatR;

namespace Application.Features.Comments.Comment.Commands.DeleteComment;

public class DeleteCommentCommandRequest:IRequest<DeleteCommentCommandResponse>
{
    public long Id { get; set; }
    
}