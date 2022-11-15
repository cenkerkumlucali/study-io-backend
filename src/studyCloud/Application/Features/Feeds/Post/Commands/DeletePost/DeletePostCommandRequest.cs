using Application.Features.Feeds.Post.Dtos;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.DeletePost;

public class DeletePostCommandRequest:IRequest<DeletePostCommandResponse>
{
    public int Id { get; set; }
 
}