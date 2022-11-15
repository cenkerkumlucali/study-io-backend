using Application.DTOs.Paging;
using Application.Features.Feeds.PostLike.Dtos;

namespace Application.Features.Feeds.PostLike.Models;

public class PostLikeListModel:BasePageableModel
{
    public IList<ListPostLikeQueryResponse> Items { get; set; }
}