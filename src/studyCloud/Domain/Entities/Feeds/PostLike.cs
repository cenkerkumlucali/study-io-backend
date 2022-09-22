using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Feeds;

public class PostLike:Entity
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
    public DateTime CreatedDate { get; set; }

    public PostLike()
    {
        
    }

    public PostLike(int id, int userId, int postId) : this()
    {
        Id = id;
        UserId = userId;
        PostId = postId;
    }
}