using MediatR;

namespace Application.Features.Comments.Comment.Commands.UpdateComment;

public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    
}