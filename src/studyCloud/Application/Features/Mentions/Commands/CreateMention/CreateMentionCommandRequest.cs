using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommandRequest:IRequest<CreateMentionCommandResponse>
{
    public long AgentId { get; set; }
    public long TargetId { get; set; }
    public long PostId { get; set; }
    public long CommentId { get; set; }
    public MentionType MentionType { get; set; }
    
    
}