using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Follows.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Follows.Models;

public class FollowListModel:BasePageableModel
{
    public IList<ListFollowDto> Items { get; set; }
}