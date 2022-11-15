using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentFile.Commands.DeleteCommentFile;

public class DeleteCommentFileCommandHandler:IRequestHandler<DeleteCommentFileCommandRequest,DeleteCommentFileCommandResponse>
{
    private ICommentImageRepository _commentImageRepository;
    private IMapper _mapper;

    public DeleteCommentFileCommandHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCommentFileCommandResponse> Handle(DeleteCommentFileCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentImageFile commentImage = _mapper.Map<Domain.Entities.Comments.CommentImageFile>(request);
        Domain.Entities.Comments.CommentImageFile deletedCommentImage =
            await _commentImageRepository.DeleteAsync(commentImage);
        DeleteCommentFileCommandResponse deletedCommentImageDto =
            _mapper.Map<DeleteCommentFileCommandResponse>(deletedCommentImage);
        return deletedCommentImageDto;
    }
}