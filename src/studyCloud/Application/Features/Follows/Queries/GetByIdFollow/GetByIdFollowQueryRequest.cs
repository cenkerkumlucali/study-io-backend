using MediatR;

namespace Application.Features.Follows.Queries.GetByIdFollow;

public class GetByIdFollowQueryRequest:IRequest<GetByIdFollowQueryResponse>
{
    public long Id { get; set; }
    
}