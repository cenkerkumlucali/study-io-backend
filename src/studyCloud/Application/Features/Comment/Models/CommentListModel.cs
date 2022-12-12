using Application.DTOs.Paging;
using Application.Features.Comment.Queries.GetListComment;

namespace Application.Features.Comment.Models;

public class CommentListModel:BasePageableModel
{
    public IList<ListCommentQueryResponse> Items { get; set; }
}