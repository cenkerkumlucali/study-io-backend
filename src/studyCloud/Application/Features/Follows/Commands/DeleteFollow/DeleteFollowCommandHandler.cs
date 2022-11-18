using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Commands.DeleteFollow;

public class DeleteFollowCommandHandler:IRequestHandler<DeleteFollowCommandRequest,DeleteFollowCommandResponse>
{
    private IFollowRepository _followRepository;
    private IMapper _mapper;

    public DeleteFollowCommandHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<DeleteFollowCommandResponse> Handle(DeleteFollowCommandRequest request, CancellationToken cancellationToken)
    {
        Follow follow = _mapper.Map<Follow>(request);
        Follow deletedFollow =
            await _followRepository.DeleteAsync(follow);
        DeleteFollowCommandResponse deletedFollowDto =
            _mapper.Map<DeleteFollowCommandResponse>(deletedFollow);
        return deletedFollowDto;
    }
}