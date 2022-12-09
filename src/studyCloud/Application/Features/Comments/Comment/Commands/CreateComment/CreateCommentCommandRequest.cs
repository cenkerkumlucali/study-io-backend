using MediatR;

namespace Application.Features.Comments.Comment.Commands.CreateComment;

public class CreateCommentCommandRequest:IRequest<CreateCommentCommandResponse>
{
    public long UserId { get; set; }
    public long PostId { get; set; }
    public long? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}