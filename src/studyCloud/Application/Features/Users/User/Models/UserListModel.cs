using Application.DTOs.Paging;
using Application.Features.Users.User.Dtos;
using Application.Features.Users.User.Queries.GetListUser;

namespace Application.Features.Users.User.Models;

public class UserListModel : BasePageableModel
{
    public IList<ListUserQueryResponse> Items { get; set; }
}