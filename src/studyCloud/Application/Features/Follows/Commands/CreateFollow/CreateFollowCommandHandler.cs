using Application.Abstractions.Services;
using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.CreateFollow;

public class CreateFollowCommandHandler : IRequestHandler<CreateFollowCommandRequest, CreateFollowCommandResponse>
{
    private readonly IFollowRepository _followRepository;
    private readonly IAlarmService _alarmService;
    private readonly IMapper _mapper;


    public CreateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper, IAlarmService alarmService)
    {
        _followRepository = followRepository;
        _mapper = mapper;
        _alarmService = alarmService;
    }   

    public async Task<CreateFollowCommandResponse> Handle(CreateFollowCommandRequest request,
        CancellationToken cancellationToken)
    {
        Follow mappedFollow = _mapper.Map<Follow>(request);
        Follow createdFollow = await _followRepository.AddAsync(mappedFollow);
        await _alarmService.Alert(createdFollow.FollowerId, createdFollow.FollowingId, createdFollow.Id);
        CreateFollowCommandResponse mappedCreateFollowDto = _mapper.Map<CreateFollowCommandResponse>(createdFollow);
        return mappedCreateFollowDto;
    }
}