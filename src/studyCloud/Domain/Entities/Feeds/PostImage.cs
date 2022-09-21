using Core.Persistence.Repositories;

namespace Domain.Entities.Feeds;

public class PostImage:Entity
{
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateDate { get; set; }

    public PostImage()
    {
        
    }

    public PostImage(int id, int postId, string imagePath, DateTime createDate) : this()
    {
        Id = id;
        PostId = postId;
        ImagePath = imagePath;
        CreateDate = createDate;
    }
}