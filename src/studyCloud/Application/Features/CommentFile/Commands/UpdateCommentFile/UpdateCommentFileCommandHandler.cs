using Application.Repositories.Services.Comments;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;

namespace Application.Features.CommentFile.Commands.UpdateCommentFile;

public class UpdateCommentFileCommandHandler:IRequestHandler<UpdateCommentFileCommandRequest,UpdateCommentFileCommandResponse>
{
    private ICommentImageFileRepository _commentImageRepository;
    private IMapper _mapper;

    public UpdateCommentFileCommandHandler(ICommentImageFileRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCommentFileCommandResponse> Handle(UpdateCommentFileCommandRequest request, CancellationToken cancellationToken)
    {
        CommentImageFile commentImage = _mapper.Map<CommentImageFile>(request);
        CommentImageFile createdCommentImage =
            await _commentImageRepository.UpdateAsync(commentImage);
        UpdateCommentFileCommandResponse  updatedCommentImageDto =
            _mapper.Map<UpdateCommentFileCommandResponse>(createdCommentImage);
        return updatedCommentImageDto;
    }
}