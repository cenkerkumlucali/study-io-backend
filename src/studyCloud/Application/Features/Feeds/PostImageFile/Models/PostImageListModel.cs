using Application.DTOs.Paging;
using Application.Features.Feeds.PostImageFile.Queries.GetListPostImage;

namespace Application.Features.Feeds.PostImageFile.Models;

public class PostImageListModel:BasePageableModel
{
    public IList<ListPostImageFileQueryResponse> Items { get; set; }
}