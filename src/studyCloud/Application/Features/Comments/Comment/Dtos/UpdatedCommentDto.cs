namespace Application.Features.Comments.Comment.Dtos;

public class UpdatedCommentDto
{
    public int Id { get; set; }
    public int ParentId {get; set;}
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}