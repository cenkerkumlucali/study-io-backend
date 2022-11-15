using Application.Features.Users.UserCoin.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Users.UserCoin.Queries.GetListUserCoin;

public class GetListUserCoinQueryRequest : IRequest<UserCoinListModel>
{
    public PageRequest PageRequest { get; set; }
}