using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandHandler:IRequestHandler<CreateFollowCommandRequest,CreateFollowCommandResponse>
{
    private readonly IFollowRepository _followRepository;
    private readonly IMapper _mapper;


    public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<CreateFollowCommandResponse> Handle(CreateFollowCommandRequest request, CancellationToken cancellationToken)
    {
        Follow mappedFollow = _mapper.Map<Follow>(request);
        Follow createdFollow = await _followRepository.AddAsync(mappedFollow);
        CreateFollowCommandResponse mappedCreateFollowDto = _mapper.Map<CreateFollowCommandResponse>(createdFollow);
        return mappedCreateFollowDto;
    }
}