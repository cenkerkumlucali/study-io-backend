using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.UpdatePostImage;

public class UpdatePostImageCommandRequest : IRequest<UpdatePostImageFileQueryResponse>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    
}