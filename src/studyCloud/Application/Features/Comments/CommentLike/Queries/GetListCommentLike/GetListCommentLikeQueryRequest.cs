using Application.Features.Comments.CommentLike.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetListCommentLike;

public class GetListCommentLikeQueryRequest : IRequest<CommentLikeListModel>
{
    public PageRequest PageRequest { get; set; }
}