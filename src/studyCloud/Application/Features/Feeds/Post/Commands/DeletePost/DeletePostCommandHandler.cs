using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.DeletePost;

public class DeletePostCommandHandler:IRequestHandler<DeletePostCommandRequest,DeletePostCommandResponse>
{
    private IPostService _postService;
    private IMapper _mapper;

    public DeletePostCommandHandler(IPostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post post = _mapper.Map<Domain.Entities.Feeds.Post>(request);
        Domain.Entities.Feeds.Post deletedPost =
            await _postService.Delete(post);
        DeletePostCommandResponse deletedPostDto =
            _mapper.Map<DeletePostCommandResponse>(deletedPost);
        return deletedPostDto;
    }
}