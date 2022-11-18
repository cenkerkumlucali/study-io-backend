
namespace Domain.Entities.Comments;

public class CommentImageFile:File
{
    public ICollection<Comment> Comments { get; set; }
}