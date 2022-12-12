using Application.Repositories.Services.Comments;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;

namespace Application.Features.CommentFile.Commands.DeleteCommentFile;

public class DeleteCommentFileCommandHandler:IRequestHandler<DeleteCommentFileCommandRequest,DeleteCommentFileCommandResponse>
{
    private ICommentImageFileRepository _commentImageRepository;
    private IMapper _mapper;

    public DeleteCommentFileCommandHandler(ICommentImageFileRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCommentFileCommandResponse> Handle(DeleteCommentFileCommandRequest request, CancellationToken cancellationToken)
    {
        CommentImageFile commentImage = _mapper.Map<CommentImageFile>(request);
        CommentImageFile deletedCommentImage =
            await _commentImageRepository.DeleteAsync(commentImage);
        DeleteCommentFileCommandResponse deletedCommentImageDto =
            _mapper.Map<DeleteCommentFileCommandResponse>(deletedCommentImage);
        return deletedCommentImageDto;
    }
}