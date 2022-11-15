using Application.DTOs.Paging;
using Application.Features.Comments.CommentFile.Queries.GetListCommentFile;

namespace Application.Features.Comments.CommentFile.Models;

public class CommentImageListModel:BasePageableModel
{
    public IList<ListCommentFileQueryResponse> Items { get; set; }
}