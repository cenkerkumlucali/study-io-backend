using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetListByUserId;

public class GetListByUserIdQueryRequest:IRequest<GetListByUserIdQueryResponse>
{
    public int UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}