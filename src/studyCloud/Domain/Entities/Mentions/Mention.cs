using Domain.Entities.Comments;
using Domain.Entities.Feeds;
using Domain.Enums;
using Domain.Entities.Common;
using Domain.Entities.Users;


namespace Domain.Entities.Mentions;

public class Mention : BaseEntity
{
    public int AgentId { get; set; }
    public virtual User Agent { get; set; }
    public int TargetId { get; set; }
    public virtual User Target { get; set; }
    public int PostId { get; set; }
    public virtual Post Post { get; set; }
    public int CommentId { get; set; }
    public virtual Comment? Comment { get; set; }
    public MentionType MentionType { get; set; }

    public Mention()
    {
    }

    public Mention(int id, MentionType mentionType, int agentId, int targetId, int postId, int commentId,
        DateTime createdDate) : this()
    {
        Id = id;
        MentionType = mentionType;
        AgentId = agentId;
        TargetId = targetId;
        PostId = postId;
        CommentId = commentId;
        CreatedDate = createdDate;
    }
}