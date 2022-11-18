using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Queries.GetByIdFollow;

public class GetByIdFollowQueryHandler:IRequestHandler<GetByIdFollowQueryRequest,GetByIdFollowQueryResponse>
{
    private readonly IFollowRepository _followRepository;
    private IMapper _mapper;

    public GetByIdFollowQueryHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdFollowQueryResponse> Handle(GetByIdFollowQueryRequest request, CancellationToken cancellationToken)
    {
        Follow? follow =
            await _followRepository.GetAsync(c => c.Id == request.Id);
        GetByIdFollowQueryResponse getByIdFollowDto =
            _mapper.Map<GetByIdFollowQueryResponse>(follow);
        return getByIdFollowDto;
    }
}