using Domain.Enums;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommandResponse
{
    public int Id { get; set; }
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int PostId { get; set; }
    public int CommentId { get; set; }
    public MentionType MentionType { get; set; }
    public DateTime CreatedDate { get; set; }
}