using Application.Features.Comments.CommentImage.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.Comments.CommentImage.Models;

public class CommentImageListModel:BasePageableModel
{
    public IList<ListCommentImageDto> Items { get; set; }
}