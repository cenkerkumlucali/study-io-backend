using MediatR;

namespace Application.Features.Feeds.Post.Commands.DeletePost;

public class DeletePostCommandRequest:IRequest<DeletePostCommandResponse>
{
    public long Id { get; set; }
 
}