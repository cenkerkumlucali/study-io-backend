using MediatR;

namespace Application.Features.Mentions.Commands.DeleteMention;

public class DeleteMentionCommandRequest:IRequest<DeleteMentionCommandResponse>
{
    public long Id { get; set; }
    
}