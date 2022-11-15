using Application.Features.Follows.Dtos;
using MediatR;

namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandRequest:IRequest<CreateFollowCommandResponse>
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
    

}