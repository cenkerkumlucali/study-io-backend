using Application.Features.Follows.Dtos;
using Application.Services.Repositories.Follows;
using AutoMapper;
using Domain.Entities.Follow;
using MediatR;

namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommand:IRequest<CreatedFollowDto>
{
    public int? FollowerId { get; set; }
    public int? FollowingId { get; set; }
    
    public class CreateFollowCommandHandler:IRequestHandler<CreateFollowCommand,CreatedFollowDto>
    {
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;


        public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
        {
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<CreatedFollowDto> Handle(CreateFollowCommand request, CancellationToken cancellationToken)
        {
            Follow mappedFollow = _mapper.Map<Follow>(request);
            Follow createdFollow = await _followRepository.AddAsync(mappedFollow);
            CreatedFollowDto mappedCreateFollowDto = _mapper.Map<CreatedFollowDto>(createdFollow);
            return mappedCreateFollowDto;
        }
    }
}