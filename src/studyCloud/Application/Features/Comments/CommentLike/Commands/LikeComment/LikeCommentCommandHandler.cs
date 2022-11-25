using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.LikeComment;

public class LikeCommentCommandHandler:IRequestHandler<LikeCommentCommandRequest,LikeCommentCommandResponse>
{
    private readonly ICommentLikeRepository _commentLikeRepository;
    private readonly IMapper _mapper;


    public LikeCommentCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<LikeCommentCommandResponse> Handle(LikeCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike mappedCommentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
        Domain.Entities.Comments.CommentLike createdCommentLike = await _commentLikeRepository.AddAsync(mappedCommentLike);
        LikeCommentCommandResponse mappedCreateCommentLikeDto = _mapper.Map<LikeCommentCommandResponse>(createdCommentLike);
        return mappedCreateCommentLikeDto;
    }
}