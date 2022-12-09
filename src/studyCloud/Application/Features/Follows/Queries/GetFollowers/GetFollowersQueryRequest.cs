using MediatR;

namespace Application.Features.Follows.Queries.GetFollowers;

public class GetFollowersQueryRequest:IRequest<GetFollowersQueryResponse>
{
    public long UserId { get; set; }
}