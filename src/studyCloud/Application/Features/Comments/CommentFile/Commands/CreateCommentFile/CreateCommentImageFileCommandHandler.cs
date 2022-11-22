using Application.Abstractions.Services;
using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentImageFileCommandHandler:IRequestHandler<CreateCommentImageFileCommandRequest,CreateCommentImageFileCommandResponse>
{
    private readonly ICommentImageFileService _commentImageFileService;
    public CreateCommentImageFileCommandHandler(ICommentImageFileService commentImageFileService)
    {
        _commentImageFileService = commentImageFileService;
    }

    public async Task<CreateCommentImageFileCommandResponse> Handle(CreateCommentImageFileCommandRequest request, CancellationToken cancellationToken)
    {
        await _commentImageFileService.Upload(request.Id, request.Files);
        return new();
    }
}