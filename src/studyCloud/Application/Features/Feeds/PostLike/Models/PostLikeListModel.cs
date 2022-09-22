using Application.Features.Feeds.PostImage.Dtos;
using Application.Features.Feeds.PostLike.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.PostLike.Models;

public class PostLikeListModel:BasePageableModel
{
    public IList<ListPostLikeDto> Items { get; set; }
}