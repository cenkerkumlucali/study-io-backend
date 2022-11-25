using MediatR;

namespace Application.Features.Follows.Queries.GetFollowings;

public class GetFollowingsQueryRequest:IRequest<List<GetFollowingsQueryResponse>>
{
    public int UserId { get; set; }
}