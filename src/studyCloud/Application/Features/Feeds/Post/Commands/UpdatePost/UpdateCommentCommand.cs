using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.UpdatePost;

public class UpdatePostCommand : IRequest<UpdatedPostDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatedPostDto>
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.Post post = _mapper.Map<Domain.Entities.Feeds.Post>(request);
            Domain.Entities.Feeds.Post createdPost =
                await _postRepository.UpdateAsync(post);
            UpdatedPostDto updatedPostDto =
                _mapper.Map<UpdatedPostDto>(createdPost);
            return updatedPostDto;
        }
    }
}