using Application.Features.Follows.Dtos;
using MediatR;

namespace Application.Features.Follows.Queries.GetByIdFollow;

public class GetByIdFollowQueryRequest:IRequest<GetByIdFollowQueryResponse>
{
    public int Id { get; set; }
    
}