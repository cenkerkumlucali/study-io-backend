using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.CreatePostLike;

public class CreatePostLikeCommandRequest:IRequest<CreatePostLikeCommandResponse>
{
    public int ParentId { get; set; }
    public int TargetId { get; set; }
    
}