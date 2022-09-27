using Core.Security.Entities;

namespace Application.Features.Comments.Comment.Dtos;

public class ListCommentDto
{
    public int Id { get; set; }
    public Domain.Entities.Comments.Comment? ParentId { get; set; }
    public string UserEmail { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}