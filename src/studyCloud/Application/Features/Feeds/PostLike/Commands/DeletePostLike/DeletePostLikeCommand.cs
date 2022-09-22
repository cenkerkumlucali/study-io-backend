using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.DeletePostLike;

public class DeletePostLikeCommand:IRequest<DeletedPostLikeDto>
{
    public int Id { get; set; }
    public class DeletePostLikeCommandHandler:IRequestHandler<DeletePostLikeCommand,DeletedPostLikeDto>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private IMapper _mapper;

        public DeletePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
        {
            _postLikeRepository = postLikeRepository;
            _mapper = mapper;
        }

        public async Task<DeletedPostLikeDto> Handle(DeletePostLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostLike postLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
            Domain.Entities.Feeds.PostLike deletedPostLike =
                await _postLikeRepository.DeleteAsync(postLike);
            DeletedPostLikeDto deletedPostLikeDto =
                _mapper.Map<DeletedPostLikeDto>(deletedPostLike);
            return deletedPostLikeDto;
        }
    }
}