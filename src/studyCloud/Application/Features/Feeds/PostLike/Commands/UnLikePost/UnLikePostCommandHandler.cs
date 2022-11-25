using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UnLikePost;

public class UnLikePostCommandHandler:IRequestHandler<UnLikePostCommandRequest,UnLikePostCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public UnLikePostCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<UnLikePostCommandResponse> Handle(UnLikePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike? postLike = await _postLikeRepository.GetAsync(c => c.UserId == request.UserId && c.PostId == request.PostId);
        Domain.Entities.Feeds.PostLike deletedPostLike =
            await _postLikeRepository.DeleteAsync(postLike);
        UnLikePostCommandResponse deletedPostLikeDto =
            _mapper.Map<UnLikePostCommandResponse>(deletedPostLike);
        return deletedPostLikeDto;
    }
}