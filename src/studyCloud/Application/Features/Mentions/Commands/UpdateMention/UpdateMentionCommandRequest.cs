using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.UpdateMention;

public class UpdateMentionCommandRequest : IRequest<UpdateMentionCommandResponse>
{
    public long Id { get; set; }
    public long AgentId { get; set; }
    public long TargetId { get; set; }
    public long PostId { get; set; }
    public long CommentId { get; set; }
    public MentionType MentionType { get; set; }

   
}