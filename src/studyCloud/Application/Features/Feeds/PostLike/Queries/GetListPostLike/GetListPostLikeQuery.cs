using Application.Features.Feeds.Post.Models;
using Application.Features.Feeds.PostImage.Models;
using Application.Features.Feeds.PostLike.Models;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetListPostLike;

public class GetListPostLikeQuery : IRequest<PostLikeListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostLikeQueryHandler : IRequestHandler<GetListPostLikeQuery, PostLikeListModel>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private IMapper _mapper;

        public GetListPostLikeQueryHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
        {
            _postLikeRepository = postLikeRepository;
            _mapper = mapper;
        }

        public async Task<PostLikeListModel> Handle(GetListPostLikeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Feeds.PostLike> postLike =
                await _postLikeRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            PostLikeListModel mappedPostLikeListModel =
                _mapper.Map<PostLikeListModel>(postLike);
            return mappedPostLikeListModel;
        }
    }
}