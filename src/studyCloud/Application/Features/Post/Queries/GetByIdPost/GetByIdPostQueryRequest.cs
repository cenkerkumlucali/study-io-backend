using MediatR;

namespace Application.Features.Post.Queries.GetByIdPost;

public class GetByIdPostQueryRequest:IRequest<GetByIdPostQueryResponse>
{
    public long Id { get; set; }
  
}