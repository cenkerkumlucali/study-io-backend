using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetUsersLikedComment;

public class GetUsersLikedCommentQueryRequest:IRequest<List<GetUsersLikedCommentQueryResponse>>
{
    public long CommentId { get; set; }
}