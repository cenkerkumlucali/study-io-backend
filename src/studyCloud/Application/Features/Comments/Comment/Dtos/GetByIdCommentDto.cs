namespace Application.Features.Comments.Comment.Dtos;

public class GetByIdCommentDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}