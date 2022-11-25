using Application.Abstractions.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.UnFollow;

public class UnFollowCommandHandler:IRequestHandler<UnFollowCommandRequest,UnFollowCommandResponse>
{
    private readonly IFollowService _followService;
    private IMapper _mapper;

    public UnFollowCommandHandler(IMapper mapper, IFollowService followService)
    {
        _mapper = mapper;
        _followService = followService;
    }

    public async Task<UnFollowCommandResponse> Handle(UnFollowCommandRequest request, CancellationToken cancellationToken)
    {
        Follow follow = _mapper.Map<Follow>(request);
        Follow deletedFollow = await _followService.DeleteAsync(follow);
        UnFollowCommandResponse deletedFollowDto =
            _mapper.Map<UnFollowCommandResponse>(deletedFollow);
        return deletedFollowDto;
    }
}