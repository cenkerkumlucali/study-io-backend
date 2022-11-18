using Application.DTOs.Paging;
using Application.Features.Users.UserCoin.Queries.GetListUserCoin;

namespace Application.Features.Users.UserCoin.Models;

public class UserCoinListModel:BasePageableModel
{
    public IList<ListUserCoinQueryResponse> Items { get; set; }
}