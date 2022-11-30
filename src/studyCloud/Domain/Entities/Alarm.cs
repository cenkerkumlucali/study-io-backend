using Domain.Entities.Comments;
using Domain.Entities.Common;
using Domain.Entities.Feeds;
using Domain.Entities.Users;
using Domain.Enums;

namespace Domain.Entities;

public class Alarm : BaseEntity
{
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int? PostId { get; set; }
    public int? CommentId { get; set; }
    public int? FollowId { get; set; }
    public AlarmType AlarmType { get; set; }
    public virtual User? Agent { get; set; }
    public virtual User? Target { get; set; }
    public virtual Post? Post { get; set; }
    public virtual Comment? Comment { get; set; }
    public virtual Follow? Follow { get; set; }
}