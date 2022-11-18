using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;

public class DeleteCommentFileCommandRequest:IRequest<DeleteCommentFileCommandResponse>
{
    public string Id { get; set; }
    public string? ImageId { get; set; }    
}