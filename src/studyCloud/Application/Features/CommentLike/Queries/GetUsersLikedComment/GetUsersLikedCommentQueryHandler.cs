using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CommentLike.Queries.GetUsersLikedComment;

public class
    GetUsersLikedCommentQueryHandler : IRequestHandler<GetUsersLikedCommentQueryRequest,
        List<GetUsersLikedCommentQueryResponse>>
{
    private ICommentLikeRepository _commentLikeRepository;
    private IMapper _mapper;

    public GetUsersLikedCommentQueryHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUsersLikedCommentQueryResponse>> Handle(GetUsersLikedCommentQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.Comments.CommentLike> commentLike = await _commentLikeRepository.GetAllAsync(
            c => c.CommentId == request.CommentId,
            include: c => c.Include(c => c.User)
                .ThenInclude(c => c.UserImageFiles));
        List<GetUsersLikedCommentQueryResponse>? response =
            _mapper.Map<List<GetUsersLikedCommentQueryResponse>>(commentLike);
        return response;
    }
}