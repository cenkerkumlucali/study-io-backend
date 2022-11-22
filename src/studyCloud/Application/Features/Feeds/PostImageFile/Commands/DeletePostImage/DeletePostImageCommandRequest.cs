using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.DeletePostImage;

public class DeletePostImageCommandRequest:IRequest<DeletePostFileCommandResponse>
{
    public int ImageId { get; set; }
}