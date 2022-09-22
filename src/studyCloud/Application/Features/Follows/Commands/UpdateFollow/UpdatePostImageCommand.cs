using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Follows.Dtos;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Follows;
using AutoMapper;
using Domain.Entities.Follow;
using MediatR;

namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommand : IRequest<UpdatedFollowDto>
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public int FollowingId { get; set; }

    public class UpdateFollowCommandHandler : IRequestHandler<UpdateFollowCommand, UpdatedFollowDto>
    {
        private readonly IFollowRepository _followRepository;
        private IMapper _mapper;

        public UpdateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedFollowDto> Handle(UpdateFollowCommand request, CancellationToken cancellationToken)
        {
            Follow follow = _mapper.Map<Follow>(request);
            Follow createdFollow =
                await _followRepository.UpdateAsync(follow);
            UpdatedFollowDto updatedFollowDto =
                _mapper.Map<UpdatedFollowDto>(createdFollow);
            return updatedFollowDto;
        }
    }
}