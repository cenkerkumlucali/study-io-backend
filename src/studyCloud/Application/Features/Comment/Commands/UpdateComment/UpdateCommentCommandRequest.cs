using MediatR;

namespace Application.Features.Comment.Commands.UpdateComment;

public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    
}