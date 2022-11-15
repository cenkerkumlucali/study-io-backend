using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.CreatePost;

public class CreatePostCommandHandler:IRequestHandler<CreatePostCommandRequest,CreatePostCommandResponse>
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;


    public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post mappedPost = _mapper.Map<Domain.Entities.Feeds.Post>(request);
        Domain.Entities.Feeds.Post createdPost = await _postRepository.AddAsync(mappedPost);
        CreatePostCommandResponse mappedCreatePostDto = _mapper.Map<CreatePostCommandResponse>(createdPost);
        return mappedCreatePostDto;
    }
}