using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.CommentLike.Models;
using Application.Services.Repositories.Comments;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetListCommentLike;

public class GetListCommentLikeQuery : IRequest<CommentLikeListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCommentLikeQueryHandler : IRequestHandler<GetListCommentLikeQuery, CommentLikeListModel>
    {
        private ICommentLikeRepository _commentLikeRepository;
        private IMapper _mapper;

        public GetListCommentLikeQueryHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<CommentLikeListModel> Handle(GetListCommentLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Comments.CommentLike> commentLike =
                await _commentLikeRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            CommentLikeListModel mappedCommentLikeListModel =
                _mapper.Map<CommentLikeListModel>(commentLike);
            return mappedCommentLikeListModel;
        }
    }
}