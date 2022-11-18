using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.DeletePost;

public class DeletePostCommandHandler:IRequestHandler<DeletePostCommandRequest,DeletePostCommandResponse>
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<DeletePostCommandResponse> Handle(DeletePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post post = _mapper.Map<Domain.Entities.Feeds.Post>(request);
        Domain.Entities.Feeds.Post deletedPost =
            await _postRepository.DeleteAsync(post);
        DeletePostCommandResponse deletedPostDto =
            _mapper.Map<DeletePostCommandResponse>(deletedPost);
        return deletedPostDto;
    }
}