using Application.Abstractions.Services.Paging;
using Application.Features.CommentLike.Models;
using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.CommentLike.Queries.GetListCommentLike;

public class GetListCommentLikeQueryHandler : IRequestHandler<GetListCommentLikeQueryRequest, CommentLikeListModel>
{
    private ICommentLikeRepository _commentLikeRepository;
    private IMapper _mapper;

    public GetListCommentLikeQueryHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<CommentLikeListModel> Handle(GetListCommentLikeQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Comments.CommentLike> commentLike =
            await _commentLikeRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        CommentLikeListModel mappedCommentLikeListModel =
            _mapper.Map<CommentLikeListModel>(commentLike);
        return mappedCommentLikeListModel;
    }
}