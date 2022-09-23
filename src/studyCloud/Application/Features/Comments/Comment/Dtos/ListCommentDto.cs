namespace Application.Features.Comments.Comment.Dtos;

public class ListCommentDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}