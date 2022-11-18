using Application.DTOs.Paging;
using Application.Features.Follows.Queries.GetListFollow;

namespace Application.Features.Follows.Models;

public class FollowListModel:BasePageableModel
{
    public IList<ListFollowQueryResponse> Items { get; set; }
}