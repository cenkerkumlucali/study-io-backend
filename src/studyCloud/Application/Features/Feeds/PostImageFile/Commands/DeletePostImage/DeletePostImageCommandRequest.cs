using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.DeletePostImage;

public class DeletePostImageCommandRequest:IRequest<DeletePostFileCommandResponse>
{
    public long ImageId { get; set; }
}