using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UnLikeComment;

public class UnLikeCommentCommandHandler:IRequestHandler<UnLikeCommentCommandRequest,UnLikeCommentCommandResponse>
{
    private ICommentLikeRepository _commentLikeRepository;
    private IMapper _mapper;

    public UnLikeCommentCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<UnLikeCommentCommandResponse> Handle(UnLikeCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike? comment = await _commentLikeRepository.GetAsync(c => c.UserId == request.UserId && c.CommentId == request.CommentId);
        Domain.Entities.Comments.CommentLike deletedCommentLike =
            await _commentLikeRepository.DeleteAsync(comment);
        UnLikeCommentCommandResponse deletedCommentLikeDto =
            _mapper.Map<UnLikeCommentCommandResponse>(deletedCommentLike);
        return deletedCommentLikeDto;
    }
}