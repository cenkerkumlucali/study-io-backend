using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.CreatePost;

public class CreatePostCommand:IRequest<CreatedPostDto>
{
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public class CreatePostCommandHandler:IRequestHandler<CreatePostCommand,CreatedPostDto>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;


        public CreatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.Post mappedPost = _mapper.Map<Domain.Entities.Feeds.Post>(request);
            Domain.Entities.Feeds.Post createdPost = await _postRepository.AddAsync(mappedPost);
            CreatedPostDto mappedCreatePostDto = _mapper.Map<CreatedPostDto>(createdPost);
            return mappedCreatePostDto;
        }
    }
}