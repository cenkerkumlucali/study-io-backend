using Application.Features.Feeds.Post.Dtos;
using Application.Features.Feeds.PostImage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.PostImage.Models;

public class PostImageListModel:BasePageableModel
{
    public IList<ListPostImageDto> Items { get; set; }
}