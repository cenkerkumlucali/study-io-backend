
namespace Application.DTOs.Post;

public class PostCommentDto
{
    public int CommentId { get; set; }
    public string FullName { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}