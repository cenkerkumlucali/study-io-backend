using Application.Features.Feeds.Post.Dtos;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.UpdatePost;

public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

   
}