using Application.Features.Feeds.PostLike.Dtos;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.CreatePostLike;

public class CreatePostLikeCommandRequest:IRequest<CreatePostLikeCommandResponse>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    
    
}