using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Post.Commands.CreatePost;

public class CreatePostCommandRequest:IRequest<CreatePostCommandResponse>
{
    public long UserId { get; set; }
    public string Content { get; set; }
    public IFormFileCollection Files { get; set; }

}