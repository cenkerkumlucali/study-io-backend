using Domain.Entities.Users;
using Domain.Entities.Common;

namespace Domain.Entities.Follow;

public class Follow:BaseEntity
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
    public virtual User? Follewer { get; set; }
    public virtual User? Following { get; set; }
    
}