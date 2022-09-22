using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.CreatePostLike;

public class CreatePostLikeCommand:IRequest<CreatedPostLikeDto>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public class CreatePostLikeCommandHandler:IRequestHandler<CreatePostLikeCommand,CreatedPostLikeDto>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly IMapper _mapper;


        public CreatePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
        {
            _postLikeRepository = postLikeRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPostLikeDto> Handle(CreatePostLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostLike mappedPostLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
            Domain.Entities.Feeds.PostLike createdPostLike = await _postLikeRepository.AddAsync(mappedPostLike);
            CreatedPostLikeDto mappedCreatePostLikeDto = _mapper.Map<CreatedPostLikeDto>(createdPostLike);
            return mappedCreatePostLikeDto;
        }
    }
}