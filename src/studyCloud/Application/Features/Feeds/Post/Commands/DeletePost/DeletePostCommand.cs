using Application.Features.Comments.Comment.Dtos;
using Application.Features.Feeds.Post.Dtos;
using Application.Services.Repositories.Comments;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.Post.Commands.DeletePost;

public class DeletePostCommand:IRequest<DeletedPostDto>
{
    public int Id { get; set; }
    public class DeletePostCommandHandler:IRequestHandler<DeletePostCommand,DeletedPostDto>
    {
        private IPostRepository _postRepository;
        private IMapper _mapper;

        public DeletePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<DeletedPostDto> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.Post post = _mapper.Map<Domain.Entities.Feeds.Post>(request);
            Domain.Entities.Feeds.Post deletedPost =
                await _postRepository.DeleteAsync(post);
            DeletedPostDto deletedPostDto =
                _mapper.Map<DeletedPostDto>(deletedPost);
            return deletedPostDto;
        }
    }
}