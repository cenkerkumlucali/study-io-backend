using Application.Features.Follows.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Follows.Queries.GetListFollow;

public class GetListFollowQueryRequest : IRequest<FollowListModel>
{
    public PageRequest PageRequest { get; set; }
}