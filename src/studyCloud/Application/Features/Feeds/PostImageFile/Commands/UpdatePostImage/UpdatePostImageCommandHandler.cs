using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImageFile.Commands.UpdatePostImage;

public class UpdatePostImageCommandHandler : IRequestHandler<UpdatePostImageCommandRequest, UpdatePostImageFileQueryResponse>
{
    private readonly IPostImageFileRepository _postImageRepository;
    private IMapper _mapper;

    public UpdatePostImageCommandHandler(IPostImageFileRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<UpdatePostImageFileQueryResponse> Handle(UpdatePostImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImageFile postImage = _mapper.Map<Domain.Entities.Feeds.PostImageFile>(request);
        Domain.Entities.Feeds.PostImageFile createdPostImage =
            await _postImageRepository.UpdateAsync(postImage);
        UpdatePostImageFileQueryResponse updatedPostImageDto =
            _mapper.Map<UpdatePostImageFileQueryResponse>(createdPostImage);
        return updatedPostImageDto;
    }
}