using Application.Abstractions.Services;
using Application.Features.Post.Dtos;
using AutoMapper;
using MediatR;

namespace Application.Features.Post.Commands.CreatePost;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommandRequest, CreatePostCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IPostService _postService;

    public CreatePostCommandHandler(IMapper mapper, IPostService postService)
    {
        _mapper = mapper;
        _postService = postService;
    }

    public async Task<CreatePostCommandResponse> Handle(CreatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post mappedPost = _mapper.Map<Domain.Entities.Feeds.Post>(request);

        PostUploadDto postUploadDto = new()
        {
            Post = mappedPost,
            Files = request.Files
        };
        PostUploadDto createdPost = await _postService.Upload(postUploadDto);
        CreatePostCommandResponse mappedCreatePostDto = _mapper.Map<CreatePostCommandResponse>(createdPost);
        return mappedCreatePostDto;
    }
}