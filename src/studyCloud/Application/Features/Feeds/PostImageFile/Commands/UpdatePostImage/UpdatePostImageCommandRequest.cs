using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.UpdatePostImage;

public class UpdatePostImageCommandRequest : IRequest<UpdatePostImageFileQueryResponse>
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    
}