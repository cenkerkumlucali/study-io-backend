namespace Domain.Entities.Feeds;

public class PostImage:File.File
{
    public ICollection<Post> Posts { get; set; }
}