using Application.Features.Users.UserCoin.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Users.UserCoin.Models;

public class UserCoinListModel:BasePageableModel
{
    public IList<ListUserCoinDto> Items { get; set; }
}