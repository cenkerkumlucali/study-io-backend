using Application.Features.Comments.Comment.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Comments.Comment.Models;

public class CommentListModel:BasePageableModel
{
    public IList<ListCommentDto> Items { get; set; }
}