using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Feeds.PostImageFile.Commands.CreatePostImage;

public class CreatePostImageFileCommandRequest:IRequest<CreatePostImageFileCommandResponse>
{
    public long Id { get; set; }
    public IFormFileCollection Files { get; set; }
}