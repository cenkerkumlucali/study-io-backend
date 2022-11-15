using Application.Features.Mentions.Dtos;
using MediatR;

namespace Application.Features.Mentions.Commands.DeleteMention;

public class DeleteMentionCommandRequest:IRequest<DeleteMentionCommandResponse>
{
    public int Id { get; set; }
    
}