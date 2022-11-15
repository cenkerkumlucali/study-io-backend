using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;

public class UpdateCommentLikeCommandHandler : IRequestHandler<UpdateCommentLikeCommandRequest, UpdateCommentLikeCommandResponse>
{
    private ICommentLikeRepository _commentLikeRepository;
    private IMapper _mapper;

    public UpdateCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCommentLikeCommandResponse> Handle(UpdateCommentLikeCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike commentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
        Domain.Entities.Comments.CommentLike createdCommentLike =
            await _commentLikeRepository.UpdateAsync(commentLike);
        UpdateCommentLikeCommandResponse updatedCommentLikeDto =
            _mapper.Map<UpdateCommentLikeCommandResponse>(createdCommentLike);
        return updatedCommentLikeDto;
    }
}