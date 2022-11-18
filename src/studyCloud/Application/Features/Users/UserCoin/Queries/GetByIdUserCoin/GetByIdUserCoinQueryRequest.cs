using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetByIdUserCoin;

public class GetByIdUserCoinQueryRequest : IRequest<GetByIdUserCoinQueryResponse>
{
    public int Id { get; set; }
    
}