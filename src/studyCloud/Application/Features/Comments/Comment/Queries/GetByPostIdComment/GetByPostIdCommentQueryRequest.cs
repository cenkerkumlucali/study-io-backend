using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetByPostIdComment;

public class GetByPostIdCommentQueryRequest:IRequest<List<GetByPostIdCommentQueryResponse>>
{
    public long PostId { get; set; }
}