using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Follow;

public class Follow:Entity
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
    public virtual User Follewer { get; set; }
    public virtual User Following { get; set; }
    public DateTime CreatedDate { get; set; }

    public Follow()
    {
        
    }

    public Follow(int id, int followerId, int followingId) : this()
    {
        Id = id;
        FollowerId = followerId;
        FollowingId = followingId;
    }
}