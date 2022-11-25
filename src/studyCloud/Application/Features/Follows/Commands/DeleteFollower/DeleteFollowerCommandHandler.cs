using Application.Abstractions.Services;
using Application.Features.Follows.Commands.UnFollow;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollower;

public class DeleteFollowerCommandHandler:IRequestHandler<DeleteFollowerCommandRequest,DeleteFollowerCommandResponse>
{
    private readonly IFollowService _followService;
    private IMapper _mapper;

    public DeleteFollowerCommandHandler(IMapper mapper, IFollowService followService)
    {
        _mapper = mapper;
        _followService = followService;
    }

    public async Task<DeleteFollowerCommandResponse> Handle(DeleteFollowerCommandRequest request, CancellationToken cancellationToken)
    {
        Follow follow = _mapper.Map<Follow>(request);
        Follow deletedFollow = await _followService.DeleteFollowerAsync(follow);
        DeleteFollowerCommandResponse deletedFollowDto =
            _mapper.Map<DeleteFollowerCommandResponse>(deletedFollow);
        return deletedFollowDto;
    }
}