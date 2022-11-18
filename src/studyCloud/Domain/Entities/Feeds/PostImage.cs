namespace Domain.Entities.Feeds;

public class PostImageFile:File
{
    public ICollection<Post> Posts { get; set; }
}