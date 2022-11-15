using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;

public class DeleteCommentFileCommandRequest:IRequest<DeleteCommentFileCommandResponse>
{
    public int Id { get; set; }
    
}