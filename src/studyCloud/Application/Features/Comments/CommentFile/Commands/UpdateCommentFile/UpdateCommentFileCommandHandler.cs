using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.UpdateCommentFile;

public class UpdateCommentFileCommandHandler:IRequestHandler<UpdateCommentFileCommandRequest,UpdateCommentFileCommandResponse>
{
    private ICommentImageRepository _commentImageRepository;
    private IMapper _mapper;

    public UpdateCommentFileCommandHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCommentFileCommandResponse> Handle(UpdateCommentFileCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentImageFile commentImage = _mapper.Map<Domain.Entities.Comments.CommentImageFile>(request);
        Domain.Entities.Comments.CommentImageFile createdCommentImage =
            await _commentImageRepository.UpdateAsync(commentImage);
        UpdateCommentFileCommandResponse  updatedCommentImageDto =
            _mapper.Map<UpdateCommentFileCommandResponse>(createdCommentImage);
        return updatedCommentImageDto;
    }
}