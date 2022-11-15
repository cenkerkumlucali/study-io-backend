using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UpdatePostLike;

public class UpdatePostLikeCommandHandler : IRequestHandler<UpdatePostLikeCommandRequest, UpdatePostLikeCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private IMapper _mapper;

    public UpdatePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<UpdatePostLikeCommandResponse> Handle(UpdatePostLikeCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike postLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
        Domain.Entities.Feeds.PostLike createdPostLike =
            await _postLikeRepository.UpdateAsync(postLike);
        UpdatePostLikeCommandResponse updatedPostLikeDto =
            _mapper.Map<UpdatePostLikeCommandResponse>(createdPostLike);
        return updatedPostLikeDto;
    }
}