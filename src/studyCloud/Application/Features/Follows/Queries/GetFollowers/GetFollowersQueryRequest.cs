using MediatR;

namespace Application.Features.Follows.Queries.GetFollowers;

public class GetFollowersQueryRequest:IRequest<GetFollowersQueryResponse>
{
    public int UserId { get; set; }
}