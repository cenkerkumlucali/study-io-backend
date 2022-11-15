using Application.DTOs.Paging;
using Application.Features.Follows.Dtos;

namespace Application.Features.Follows.Models;

public class FollowListModel:BasePageableModel
{
    public IList<ListFollowQueryResponse> Items { get; set; }
}