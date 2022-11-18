using Application.Repositories.Services.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.CreatePostImage;

public class CreatePostImageCommandHandler:IRequestHandler<CreatePostImageCommandRequest,CreatePostFileCommandResponse>
{
    private readonly IPostImageRepository _postImageRepository;
    private readonly IMapper _mapper;


    public CreatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
    {
        _postImageRepository = postImageRepository;
        _mapper = mapper;
    }

    public async Task<CreatePostFileCommandResponse> Handle(CreatePostImageCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Feeds.PostImageFile mappedPostImage = _mapper.Map<Domain.Entities.Feeds.PostImageFile>(request);
        Domain.Entities.Feeds.PostImageFile createdPostImage = await _postImageRepository.AddAsync(mappedPostImage);
        CreatePostFileCommandResponse mappedCreatePostImageDto = _mapper.Map<CreatePostFileCommandResponse>(createdPostImage);
        return mappedCreatePostImageDto;
    }
}