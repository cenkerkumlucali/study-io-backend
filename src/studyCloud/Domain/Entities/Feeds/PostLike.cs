using Domain.Entities.Common;
using Domain.Entities.Users;

namespace Domain.Entities.Feeds;

public class PostLike:BaseEntity
{
    public long UserId { get; set; }
    public long PostId { get; set; }
    public virtual User User { get; set; }
    public virtual Post Post { get; set; }
    
}