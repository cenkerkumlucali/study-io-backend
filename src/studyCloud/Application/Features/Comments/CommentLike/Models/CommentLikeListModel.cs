using Application.DTOs.Paging;
using Application.Features.Comments.CommentLike.Dtos;

namespace Application.Features.Comments.CommentLike.Models;

public class CommentLikeListModel:BasePageableModel
{
    public IList<ListCommentLikeQueryResponse> Items { get; set; }
}