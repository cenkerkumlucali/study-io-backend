using Domain.Entities.Comments;
using Domain.Entities.Common;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities;

public class Alarm : BaseEntity
{
    public long AgentId { get; set; }
    public long TargetId { get; set; }
    public long PostId { get; set; }
    public long CommentId { get; set; }
    public long FollowId { get; set; }
    public AlarmType AlarmType { get; set; }
    public virtual User? Agent { get; set; }
    public virtual User? Target { get; set; }
    public virtual Post? Post { get; set; }
    public virtual Comment? Comment { get; set; }
    public virtual Follow? Follow { get; set; }
}