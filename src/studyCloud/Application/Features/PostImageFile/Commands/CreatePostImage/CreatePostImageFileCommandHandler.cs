using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.PostImageFile.Commands.CreatePostImage;

public class
    CreatePostImageFileCommandHandler : IRequestHandler<CreatePostImageFileCommandRequest,
        CreatePostImageFileCommandResponse>
{
    private readonly IPostImageFileService _postImageFileService;

    public CreatePostImageFileCommandHandler(IPostImageFileService postImageFileService)
    {
        _postImageFileService = postImageFileService;
    }

    public async Task<CreatePostImageFileCommandResponse> Handle(CreatePostImageFileCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _postImageFileService.Upload(request.Id, request.Files);
        return new();
    }
}