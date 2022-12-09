using Domain.Enums;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommandResponse
{
    public long Id { get; set; }
    public long AgentId { get; set; }
    public long TargetId { get; set; }
    public long PostId { get; set; }
    public long CommentId { get; set; }
    public MentionType MentionType { get; set; }
    public DateTime CreatedDate { get; set; }
}