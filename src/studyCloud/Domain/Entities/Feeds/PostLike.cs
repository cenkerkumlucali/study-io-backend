using Domain.Entities.Common;
using Domain.Entities.Users;

namespace Domain.Entities.Feeds;

public class PostLike:BaseEntity
{
    public int UserId { get; set; }
    public int PostId { get; set; }
    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
    
}