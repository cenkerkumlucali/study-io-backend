using MediatR;

namespace Application.Features.Comment.Commands.DeleteComment;

public class DeleteCommentCommandRequest:IRequest<DeleteCommentCommandResponse>
{
    public long Id { get; set; }
    
}