using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.DeletePostImage;

public class DeletePostImageCommandHandler:IRequestHandler<DeletePostImageCommandRequest,DeletePostFileCommandResponse>
{
    private IPostImageFileRepository _postImageRepository;
    private IMapper _mapper;

    public DeletePostImageCommandHandler(IPostImageFileRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<DeletePostFileCommandResponse> Handle(DeletePostImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImageFile postImage = _mapper.Map<Domain.Entities.Feeds.PostImageFile>(request);
        Domain.Entities.Feeds.PostImageFile deletedPostImage =
            await _postImageRepository.DeleteAsync(postImage);
        DeletePostFileCommandResponse deletedPostImageDto =
            _mapper.Map<DeletePostFileCommandResponse>(deletedPostImage);
        return deletedPostImageDto;
    }
}