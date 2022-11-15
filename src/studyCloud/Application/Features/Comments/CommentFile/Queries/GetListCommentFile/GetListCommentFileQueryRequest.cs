using Application.Features.Comments.CommentFile.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Comments.CommentFile.Queries.GetListCommentFile;

public class GetListCommentFileQueryRequest : IRequest<CommentImageListModel>
{
    public PageRequest PageRequest { get; set; }
}