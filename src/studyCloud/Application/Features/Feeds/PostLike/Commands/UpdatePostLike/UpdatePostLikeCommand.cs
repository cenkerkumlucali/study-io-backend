using Application.Features.Feeds.PostLike.Dtos;
using Application.Services.Repositories.Feeds;
using AutoMapper;
using MediatR;

namespace Application.Features.Feeds.PostLike.Commands.UpdatePostLike;

public class UpdatePostLikeCommand : IRequest<UpdatedPostLikeDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    public class UpdatePostLikeCommandHandler : IRequestHandler<UpdatePostLikeCommand, UpdatedPostLikeDto>
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private IMapper _mapper;

        public UpdatePostLikeCommandHandler(IPostLikeRepository postLikeRepository, IMapper mapper)
        {
            _postLikeRepository = postLikeRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPostLikeDto> Handle(UpdatePostLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Feeds.PostLike postLike = _mapper.Map<Domain.Entities.Feeds.PostLike>(request);
            Domain.Entities.Feeds.PostLike createdPostLike =
                await _postLikeRepository.UpdateAsync(postLike);
            UpdatedPostLikeDto updatedPostLikeDto =
                _mapper.Map<UpdatedPostLikeDto>(createdPostLike);
            return updatedPostLikeDto;
        }
    }
}