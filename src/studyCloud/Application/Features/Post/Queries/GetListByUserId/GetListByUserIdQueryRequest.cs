using MediatR;

namespace Application.Features.Post.Queries.GetListByUserId;

public class GetListByUserIdQueryRequest:IRequest<GetListByUserIdQueryResponse>
{
    public long UserId { get; set; }
    public int Page { get; set; }
    public int Size { get; set; }
}