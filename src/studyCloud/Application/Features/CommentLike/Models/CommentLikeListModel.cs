using Application.DTOs.Paging;
using Application.Features.CommentLike.Queries.GetListCommentLike;

namespace Application.Features.CommentLike.Models;

public class CommentLikeListModel:BasePageableModel
{
    public IList<ListCommentLikeQueryResponse> Items { get; set; }
}