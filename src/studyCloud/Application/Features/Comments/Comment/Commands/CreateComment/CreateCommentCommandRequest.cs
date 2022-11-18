using MediatR;

namespace Application.Features.Comments.Comment.Commands.CreateComment;

public class CreateCommentCommandRequest:IRequest<CreateCommentCommandResponse>
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public int? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    
}