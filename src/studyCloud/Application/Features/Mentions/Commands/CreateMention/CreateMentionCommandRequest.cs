using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.CreateMention;

public class CreateMentionCommandRequest:IRequest<CreateMentionCommandResponse>
{
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int PostId { get; set; }
    public int CommentId { get; set; }
    public MentionType MentionType { get; set; }
    
    
}