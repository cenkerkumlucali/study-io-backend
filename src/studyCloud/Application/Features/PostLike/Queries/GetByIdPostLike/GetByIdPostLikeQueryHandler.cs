using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.PostLike.Queries.GetByIdPostLike;

public class GetByIdPostLikeQueryHandler:IRequestHandler<GetByIdPostLikeQueryRequest,GetByIdPostLikeQueryResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public GetByIdPostLikeQueryHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdPostLikeQueryResponse> Handle(GetByIdPostLikeQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike? postLike =
            await _postLikeRepository.GetAsync(c => c.Id == request.Id);
        GetByIdPostLikeQueryResponse getByIdPostLikeDto =
            _mapper.Map<GetByIdPostLikeQueryResponse>(postLike);
        return getByIdPostLikeDto;
    }
}