using Application.Abstractions.Services.Paging;
using Application.Abstractions.Storage;
using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.CreateCommentFile;

public class CreateCommentImageFileCommandHandler:IRequestHandler<CreateCommentImageFileCommandRequest,CreateCommentImageFileCommandResponse>
{
    private readonly ICommentImageRepository _commentImageRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public CreateCommentImageFileCommandHandler(
        ICommentImageRepository commentImageRepository,
        IMapper mapper, 
        IStorageService storageService, 
        ICommentRepository commentRepository)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
        _storageService = storageService;
        _commentRepository = commentRepository;
    }

    public async Task<CreateCommentImageFileCommandResponse> Handle(CreateCommentImageFileCommandRequest request, CancellationToken cancellationToken)
    {
        List<(string fileName, string pathOrContainerName)> result =
            await _storageService.UploadAsync("study.io-comment-image", request.Files);
        Domain.Entities.Comments.Comment? comment = await _commentRepository.GetAsync(c => c.Id == request.Id);
        await _commentImageRepository.AddRangeAsync(result.Select(r => new Domain.Entities.Comments.CommentImageFile
        {
            FileName = r.fileName,
            Path = r.pathOrContainerName,
            Storage = _storageService.StorageName,
            Comments = new List<Domain.Entities.Comments.Comment>() { comment }
        }).ToList());
        // Domain.Entities.Comments.CommentImageFile mappedCommentImage = _mapper.Map<Domain.Entities.Comments.CommentImageFile>(request);
        // Domain.Entities.Comments.CommentImageFile createdCommentImage = await _commentImageRepository.AddAsync(mappedCommentImage);
        // CreateCommentFileCommandResponse mappedCreateCommentImageDto = _mapper.Map<CreateCommentFileCommandResponse>(createdCommentImage);
        return new();
    }
}