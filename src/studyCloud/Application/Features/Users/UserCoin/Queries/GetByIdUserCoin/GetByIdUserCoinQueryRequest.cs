using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;

public class GetByIdUserCoinQueryRequest : IRequest<GetByIdUserCoinQueryResponse>
{
    public long Id { get; set; }
    
}