using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.DeletePostLike;

public class DeletePostLikeCommandHandler:IRequestHandler<DeletePostLikeCommandRequest,DeletePostLikeCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public DeletePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<DeletePostLikeCommandResponse> Handle(DeletePostLikeCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike postLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
        Domain.Entities.Feeds.PostLike deletedPostLike =
            await _postLikeRepository.DeleteAsync(postLike);
        DeletePostLikeCommandResponse deletedPostLikeDto =
            _mapper.Map<DeletePostLikeCommandResponse>(deletedPostLike);
        return deletedPostLikeDto;
    }
}