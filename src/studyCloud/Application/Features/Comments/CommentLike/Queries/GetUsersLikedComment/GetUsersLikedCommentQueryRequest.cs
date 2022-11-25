using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetUsersLikedComment;

public class GetUsersLikedCommentQueryRequest:IRequest<List<GetUsersLikedCommentQueryResponse>>
{
    public int CommentId { get; set; }
}