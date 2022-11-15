using MediatR;

namespace Application.Features.Comments.Comment.Commands.DeleteComment;

public class DeleteCommentCommandRequest:IRequest<DeleteCommentCommandResponse>
{
    public int Id { get; set; }
    
}