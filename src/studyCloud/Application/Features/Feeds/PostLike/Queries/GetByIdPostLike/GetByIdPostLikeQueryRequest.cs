using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetByIdPostLike;

public class GetByIdPostLikeQueryRequest:IRequest<GetByIdPostLikeQueryResponse>
{
    public long Id { get; set; }
    
}