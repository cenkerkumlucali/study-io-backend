using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetMembersLikedPost;

public class GetMembersLikedPostQueryRequest:IRequest<List<GetMembersLikedPostQueryResponse>>
{
    public long PostId { get; set; }
}