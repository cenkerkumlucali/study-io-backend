using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Feeds.Post.Commands.CreatePost;

public class CreatePostCommandRequest:IRequest<CreatePostCommandResponse>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public IFormFileCollection Files { get; set; }

}