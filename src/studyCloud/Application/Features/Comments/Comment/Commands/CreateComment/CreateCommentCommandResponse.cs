namespace Application.Features.Comments.Comment.Commands.CreateComment;

public class CreateCommentCommandResponse
{
    public int Id { get; set; }
    public int ParentId {get; set;}
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}