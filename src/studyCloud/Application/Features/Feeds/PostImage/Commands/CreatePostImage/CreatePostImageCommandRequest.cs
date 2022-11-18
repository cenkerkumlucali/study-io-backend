using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.CreatePostImage;

public class CreatePostImageCommandRequest:IRequest<CreatePostFileCommandResponse>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    
}