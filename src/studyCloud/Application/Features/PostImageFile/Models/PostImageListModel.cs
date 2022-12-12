using Application.DTOs.Paging;
using Application.Features.PostImageFile.Queries.GetListPostImage;

namespace Application.Features.PostImageFile.Models;

public class PostImageListModel:BasePageableModel
{
    public IList<ListPostImageFileQueryResponse> Items { get; set; }
}