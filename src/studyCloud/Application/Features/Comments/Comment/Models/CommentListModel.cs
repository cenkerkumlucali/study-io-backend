using Application.DTOs.Paging;
using Application.Features.Comments.Comment.Queries.GetListComment;

namespace Application.Features.Comments.Comment.Models;

public class CommentListModel:BasePageableModel
{
    public IList<ListCommentQueryResponse> Items { get; set; }
}