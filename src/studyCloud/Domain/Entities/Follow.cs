using Domain.Entities.Common;
using Domain.Entities.Users;

namespace Domain.Entities;

public class Follow:BaseEntity
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
    public virtual User? Follewer { get; set; }
    public virtual User? Following { get; set; }
    
}