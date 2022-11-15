using Application.Features.Follows.Dtos;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollow;

public class DeleteFollowCommandRequest:IRequest<DeleteFollowCommandResponse>
{
    public int Id { get; set; }
    
}