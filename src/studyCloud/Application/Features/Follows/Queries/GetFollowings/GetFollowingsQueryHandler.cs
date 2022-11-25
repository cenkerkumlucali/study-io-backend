using Application.Repositories.Services.Follows;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Follows.Queries.GetFollowings;

public class GetFollowingsQueryHandler : IRequestHandler<GetFollowingsQueryRequest, List<GetFollowingsQueryResponse>>
{
    private readonly IFollowRepository _followRepository;
    private IMapper _mapper;

    public GetFollowingsQueryHandler(IFollowRepository followRepository, IMapper mapper)
    {
        _followRepository = followRepository;
        _mapper = mapper;
    }

    public async Task<List<GetFollowingsQueryResponse>> Handle(GetFollowingsQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Follow> followings = await _followRepository.GetAllAsync(c => c.FollowerId == request.UserId,
            include: c => c.Include(c => c.Following));
        List<GetFollowingsQueryResponse>? response = _mapper.Map<List<GetFollowingsQueryResponse>>(followings);
        return response;
    }
}