
using Domain.Entities.Comments;

namespace Domain.Entities.ImageFile;

public class CommentImageFile:File
{
    public ICollection<Comment> Comments { get; set; }
}