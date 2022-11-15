using Application.DTOs.Paging;
using Application.Features.Feeds.Post.Dtos;

namespace Application.Features.Feeds.Post.Models;

public class PostListModel:BasePageableModel
{
    public IList<ListPostQueryResponse> Items { get; set; }
}