using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.UpdatePostImage;

public class UpdatePostImageCommandRequest : IRequest<UpdatedPostFileQueryResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    
}