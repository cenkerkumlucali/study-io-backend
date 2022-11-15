using Application.Features.Feeds.Post.Dtos;
using MediatR;

namespace Application.Features.Feeds.Post.Queries.GetByIdPost;

public class GetByIdPostQueryRequest:IRequest<GetByIdPostQueryResponse>
{
    public int Id { get; set; }
  
}