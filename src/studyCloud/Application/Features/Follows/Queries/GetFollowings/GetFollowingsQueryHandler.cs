using Application.Abstractions.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Follows.Queries.GetFollowings;

public class GetFollowingsQueryHandler : IRequestHandler<GetFollowingsQueryRequest, List<GetFollowingsQueryResponse>>
{
    private readonly IFollowService _followService;
    private IMapper _mapper;

    public GetFollowingsQueryHandler(IMapper mapper, IFollowService followService)
    {
        _mapper = mapper;
        _followService = followService;
    }

    public async Task<List<GetFollowingsQueryResponse>> Handle(GetFollowingsQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Follow> followings = await _followService.GetFollowings(request.UserId);
        List<GetFollowingsQueryResponse>? response = _mapper.Map<List<GetFollowingsQueryResponse>>(followings);
        return response;
    }
}