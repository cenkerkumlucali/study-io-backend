using Application.DTOs.Paging;
using Application.Features.Feeds.Post.Queries.GetListPost;

namespace Application.Features.Feeds.Post.Models;

public class PostListModel:BasePageableModel
{
    public IList<GetListPostQueryResponse> Items { get; set; }
}