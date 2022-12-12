using Application.Features.CommentLike.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.CommentLike.Queries.GetListCommentLike;

public class GetListCommentLikeQueryRequest : IRequest<CommentLikeListModel>
{
    public PageRequest PageRequest { get; set; }
}