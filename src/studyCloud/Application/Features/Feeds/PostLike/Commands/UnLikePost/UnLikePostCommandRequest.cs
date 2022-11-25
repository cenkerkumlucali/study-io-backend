using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UnLikePost;

public class UnLikePostCommandRequest:IRequest<UnLikePostCommandResponse>
{
    public int Id { get; set; }
    
}