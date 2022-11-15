using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.DeletePostImage;

public class DeletePostImageCommandHandler:IRequestHandler<DeletePostImageCommandRequest,DeletePostFileCommandResponse>
{
    private IPostImageRepository _postImageRepository;
    private IMapper _mapper;

    public DeletePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<DeletePostFileCommandResponse> Handle(DeletePostImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImage postImage = _mapper.Map<Domain.Entities.Feeds.PostImage>(request);
        Domain.Entities.Feeds.PostImage deletedPostImage =
            await _postImageRepository.DeleteAsync(postImage);
        DeletePostFileCommandResponse deletedPostImageDto =
            _mapper.Map<DeletePostFileCommandResponse>(deletedPostImage);
        return deletedPostImageDto;
    }
}