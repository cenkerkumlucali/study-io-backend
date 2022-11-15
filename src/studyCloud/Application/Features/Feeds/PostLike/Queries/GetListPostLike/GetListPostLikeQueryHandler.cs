using Application.Abstractions.Services.Paging;
using Application.Features.Feeds.PostLike.Models;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetListPostLike;

public class GetListPostLikeQueryHandler : IRequestHandler<GetListPostLikeQueryRequest, PostLikeListModel>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public GetListPostLikeQueryHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<PostLikeListModel> Handle(GetListPostLikeQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Feeds.PostLike> postLike =
            await _postLikeRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
        PostLikeListModel mappedPostLikeListModel =
            _mapper.Map<PostLikeListModel>(postLike);
        return mappedPostLikeListModel;
    }
}