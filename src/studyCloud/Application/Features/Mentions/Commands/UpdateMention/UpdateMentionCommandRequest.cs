using Domain.Enums;
using MediatR;

namespace Application.Features.Mentions.Commands.UpdateMention;

public class UpdateMentionCommandRequest : IRequest<UpdateMentionCommandResponse>
{
    public int Id { get; set; }
    public int AgentId { get; set; }
    public int TargetId { get; set; }
    public int PostId { get; set; }
    public int CommentId { get; set; }
    public MentionType MentionType { get; set; }

   
}