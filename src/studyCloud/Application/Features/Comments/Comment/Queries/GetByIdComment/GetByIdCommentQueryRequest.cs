using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetByIdComment;

public class GetByIdCommentQueryRequest:IRequest<GetByIdCommentQueryResponse>
{
    public long Id { get; set; }
   
}