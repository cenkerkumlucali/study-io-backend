using Application.Features.Follows.Dtos;
using Application.Services.Repositories.Feeds;
using Application.Services.Repositories.Follows;
using AutoMapper;
using Domain.Entities.Follow;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollow;

public class DeleteFollowCommand:IRequest<DeletedFollowDto>
{
    public int Id { get; set; }
    public class DeleteFollowCommandHandler:IRequestHandler<DeleteFollowCommand,DeletedFollowDto>
    {
        private IFollowRepository _followRepository;
        private IMapper _mapper;

        public DeleteFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<DeletedFollowDto> Handle(DeleteFollowCommand request, CancellationToken cancellationToken)
        {
            Follow follow = _mapper.Map<Follow>(request);
            Follow deletedFollow =
                await _followRepository.DeleteAsync(follow);
            DeletedFollowDto deletedFollowDto =
                _mapper.Map<DeletedFollowDto>(deletedFollow);
            return deletedFollowDto;
        }
    }
}