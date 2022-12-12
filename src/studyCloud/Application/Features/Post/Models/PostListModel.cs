using Application.DTOs.Paging;
using Application.Features.Post.Queries.GetListPost;

namespace Application.Features.Post.Models;

public class PostListModel:BasePageableModel
{
    public IList<GetListPostQueryResponse> Items { get; set; }
}