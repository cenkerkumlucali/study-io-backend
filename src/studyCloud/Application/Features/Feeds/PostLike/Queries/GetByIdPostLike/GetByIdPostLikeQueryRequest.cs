using Application.Features.Feeds.PostLike.Dtos;
using MediatR;

namespace Application.Features.Feeds.PostLike.Queries.GetByIdPostLike;

public class GetByIdPostLikeQueryRequest:IRequest<GetByIdPostLikeQueryResponse>
{
    public int Id { get; set; }
    
}