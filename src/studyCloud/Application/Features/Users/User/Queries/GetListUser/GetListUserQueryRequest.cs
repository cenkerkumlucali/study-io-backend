using Application.Features.Users.User.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Users.User.Queries.GetListUser;

public class GetListUserQueryRequest : IRequest<UserListModel>
{
    public PageRequest PageRequest { get; set; }

}