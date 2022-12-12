using MediatR;

namespace Application.Features.PostLike.Queries.GetMembersLikedPost;

public class GetMembersLikedPostQueryRequest:IRequest<List<GetMembersLikedPostQueryResponse>>
{
    public long PostId { get; set; }
}