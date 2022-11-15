using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentFileCommandRequest:IRequest<CreateCommentFileCommandResponse>
{
    public int CommentId { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }
    
    
}