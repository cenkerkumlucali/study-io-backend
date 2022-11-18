using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.UpdateFollow;

public class UpdateFollowCommandHandler : IRequestHandler<UpdateFollowCommandRequest, UpdateFollowCommandResponse>
{
    private readonly IFollowRepository _followRepository;
    private IMapper _mapper;

    public UpdateFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<UpdateFollowCommandResponse> Handle(UpdateFollowCommandRequest request, CancellationToken cancellationToken)
    {
        Follow follow = _mapper.Map<Follow>(request);
        Follow createdFollow =
            await _followRepository.UpdateAsync(follow);
        UpdateFollowCommandResponse updatedFollowDto =
            _mapper.Map<UpdateFollowCommandResponse>(createdFollow);
        return updatedFollowDto;
    }
}