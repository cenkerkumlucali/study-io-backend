using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.CreatePostLike;

public class CreatePostLikeCommandHandler:IRequestHandler<CreatePostLikeCommandRequest,CreatePostLikeCommandResponse>
{
    private readonly IPostLikeRepository _postLikeRepository;
    private readonly IMapper _mapper;


    public CreatePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
    {
        _postLikeRepository = postLikeRepository;
        _mapper = mapper;
    }

    public async Task<CreatePostLikeCommandResponse> Handle(CreatePostLikeCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostLike mappedPostLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
        Domain.Entities.Feeds.PostLike createdPostLike = await _postLikeRepository.AddAsync(mappedPostLike);
        CreatePostLikeCommandResponse mappedCreatePostLikeDto = _mapper.Map<CreatePostLikeCommandResponse>(createdPostLike);
        return mappedCreatePostLikeDto;
    }
}