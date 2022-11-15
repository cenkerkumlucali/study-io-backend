
namespace Domain.Entities.Comments;

public class CommentImageFile:File.File
{
    public ICollection<Comment> Comments { get; set; }
}