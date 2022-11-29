using MediatR;

namespace Application.Features.Users.Block.Queries.GetByUserId;

public class GetByUserIdQueryRequest:IRequest<List<GetByUserIdQueryResponse>>
{
    public int UserId { get; set; }
}