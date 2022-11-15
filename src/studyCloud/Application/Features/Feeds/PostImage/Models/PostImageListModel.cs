using Application.DTOs.Paging;
using Application.Features.Feeds.PostImage.Dtos;

namespace Application.Features.Feeds.PostImage.Models;

public class PostImageListModel:BasePageableModel
{
    public IList<ListPostFileQueryResponse> Items { get; set; }
}