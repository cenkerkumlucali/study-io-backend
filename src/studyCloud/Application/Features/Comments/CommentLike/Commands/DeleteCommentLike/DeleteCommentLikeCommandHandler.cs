using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;

public class DeleteCommentLikeCommandHandler:IRequestHandler<DeleteCommentLikeCommandRequest,DeleteCommentLikeCommandResponse>
{
    private ICommentLikeRepository _commentLikeRepository;
    private IMapper _mapper;

    public DeleteCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCommentLikeCommandResponse> Handle(DeleteCommentLikeCommandRequest Response, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike commentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(Response);
        Domain.Entities.Comments.CommentLike deletedCommentLike =
            await _commentLikeRepository.DeleteAsync(commentLike);
        DeleteCommentLikeCommandResponse deletedCommentLikeDto =
            _mapper.Map<DeleteCommentLikeCommandResponse>(deletedCommentLike);
        return deletedCommentLikeDto;
    }
}