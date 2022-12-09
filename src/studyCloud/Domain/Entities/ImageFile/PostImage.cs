using Domain.Entities.Feeds;

namespace Domain.Entities.ImageFile;

public class PostImageFile:File
{
    public ICollection<Post> Posts { get; set; }
}