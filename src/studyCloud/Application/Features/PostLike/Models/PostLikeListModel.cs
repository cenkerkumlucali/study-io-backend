using Application.DTOs.Paging;
using Application.Features.PostLike.Queries.GetListPostLike;

namespace Application.Features.PostLike.Models;

public class PostLikeListModel:BasePageableModel
{
    public IList<ListPostLikeQueryResponse> Items { get; set; }
}