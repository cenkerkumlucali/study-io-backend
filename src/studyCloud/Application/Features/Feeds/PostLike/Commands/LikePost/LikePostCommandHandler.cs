using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.LikePost;

public class LikePostCommandHandler:IRequestHandler<LikePostCommandRequest,LikePostCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IMapper _mapper;


    public LikePostCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<LikePostCommandResponse> Handle(LikePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike mappedPostLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
        Domain.Entities.Feeds.PostLike createdPostLike = await _postLikeRepository.AddAsync(mappedPostLike);
        LikePostCommandResponse mappedCreatePostLikeDto = _mapper.Map<LikePostCommandResponse>(createdPostLike);
        return mappedCreatePostLikeDto;
    }
}