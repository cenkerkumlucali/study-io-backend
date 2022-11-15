using Application.Features.Feeds.Post.Dtos;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.CreatePost;

public class CreatePostCommandRequest:IRequest<CreatePostCommandResponse>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
   
}