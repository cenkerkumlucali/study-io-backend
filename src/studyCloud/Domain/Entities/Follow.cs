using Domain.Entities.Common;
using Domain.Entities.Users;

namespace Domain.Entities;

public class Follow : BaseEntity
{
    public long FollowerId { get; set; }
    public long FollowingId { get; set; }
    public virtual User? Follower { get; set; }
    public virtual User? Following { get; set; }
}