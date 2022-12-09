using MediatR;

namespace Application.Features.Follows.Queries.GetFollowings;

public class GetFollowingsQueryRequest:IRequest<List<GetFollowingsQueryResponse>>
{
    public long UserId { get; set; }
}