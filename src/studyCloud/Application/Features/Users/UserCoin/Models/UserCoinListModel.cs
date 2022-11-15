using Application.DTOs.Paging;
using Application.Features.Users.UserCoin.Dtos;

namespace Application.Features.Users.UserCoin.Models;

public class UserCoinListModel:BasePageableModel
{
    public IList<ListUserCoinQueryResponse> Items { get; set; }
}