using Application.Features.Comments.Comment.Dtos;
using Application.Features.Feeds.Post.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Feeds.Post.Models;

public class PostListModel:BasePageableModel
{
    public IList<ListPostDto> Items { get; set; }
}