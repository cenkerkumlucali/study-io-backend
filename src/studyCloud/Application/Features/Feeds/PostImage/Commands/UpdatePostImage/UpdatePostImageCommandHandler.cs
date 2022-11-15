using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.UpdatePostImage;

public class UpdatePostImageCommandHandler : IRequestHandler<UpdatePostImageCommandRequest, UpdatedPostFileQueryResponse>
{
    private readonly IPostImageRepository _postImageRepository;
    private IMapper _mapper;

    public UpdatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedPostFileQueryResponse> Handle(UpdatePostImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImage postImage = _mapper.Map<Domain.Entities.Feeds.PostImage>(request);
        Domain.Entities.Feeds.PostImage createdPostImage =
            await _postImageRepository.UpdateAsync(postImage);
        UpdatedPostFileQueryResponse updatedPostImageDto =
            _mapper.Map<UpdatedPostFileQueryResponse>(createdPostImage);
        return updatedPostImageDto;
    }
}