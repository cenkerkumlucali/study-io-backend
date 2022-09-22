using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentLike.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Comments.CommentLike.Models;

public class CommentLikeListModel:BasePageableModel
{
    public IList<ListCommentLikeDto> Items { get; set; }
}