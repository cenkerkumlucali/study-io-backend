using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.UpdatePost;

public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
{
    private IPostRepository _postRepository;
    private IMapper _mapper;

    public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public async Task<UpdatePostCommandResponse> Handle(UpdatePostCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.Post post = _mapper.Map<Domain.Entities.Feeds.Post>(request);
        Domain.Entities.Feeds.Post createdPost =
            await _postRepository.UpdateAsync(post);
        UpdatePostCommandResponse updatedPostDto =
            _mapper.Map<UpdatePostCommandResponse>(createdPost);
        return updatedPostDto;
    }
}