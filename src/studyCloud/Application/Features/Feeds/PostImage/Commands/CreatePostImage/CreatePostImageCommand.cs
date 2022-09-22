using Application.Features.Feeds.PostImage.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostImage.Commands.CreatePostImage;

public class CreatePostImageCommand:IRequest<CreatedPostImageDto>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public class CreatePostImageCommandHandler:IRequestHandler<CreatePostImageCommand,CreatedPostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;


        public CreatePostImageCommandHandler(IPostImageRepository postImageRepository, IMapper mapper)
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPostImageDto> Handle(CreatePostImageCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostImage mappedPostImage = _mapper.Map<Domain.Entities.Feeds.PostImage>(request);
            Domain.Entities.Feeds.PostImage createdPostImage = await _postImageRepository.AddAsync(mappedPostImage);
            CreatedPostImageDto mappedCreatePostImageDto = _mapper.Map<CreatedPostImageDto>(createdPostImage);
            return mappedCreatePostImageDto;
        }
    }
}