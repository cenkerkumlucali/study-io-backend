using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryRequest:IRequest<GetByIdPostQueryResponse>
{
    public long Id { get; set; }
  
}