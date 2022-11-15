using Application.Features.Feeds.PostLike.Dtos;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UpdatePostLike;

public class UpdatePostLikeCommandRequest : IRequest<UpdatePostLikeCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PostId { get; set; }
}