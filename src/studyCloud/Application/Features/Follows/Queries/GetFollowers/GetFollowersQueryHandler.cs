using Application.Abstractions.Services;
using Application.Features.Follows.Dtos;
using MediatR;

namespace Application.Features.Follows.Queries.GetFollowers;

public class GetFollowersQueryHandler : IRequestHandler<GetFollowersQueryRequest, GetFollowersQueryResponse>
{
    private IFollowService _followService;

    public GetFollowersQueryHandler(IFollowService followService)
    {
        _followService = followService;
    }

    public async Task<GetFollowersQueryResponse> Handle(GetFollowersQueryRequest request,
        CancellationToken cancellationToken)
    {
        FollowerDto result = await  _followService.GetFollowers(request.UserId);
        return new GetFollowersQueryResponse()
        {
            Detail = result.Detail
        };
    }
}