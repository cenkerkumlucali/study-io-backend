using Application.Features.Feeds.PostLike.Dtos;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.DeletePostLike;

public class DeletePostLikeCommandRequest:IRequest<DeletePostLikeCommandResponse>
{
    public int Id { get; set; }
    
}