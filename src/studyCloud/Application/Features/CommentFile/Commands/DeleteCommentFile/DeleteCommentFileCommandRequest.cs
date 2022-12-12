using MediatR;

namespace Application.Features.CommentFile.Commands.DeleteCommentFile;

public class DeleteCommentFileCommandRequest:IRequest<DeleteCommentFileCommandResponse>
{
    public long Id { get; set; }
    public string? ImageId { get; set; }    
}