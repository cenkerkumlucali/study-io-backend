using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetByIdComment;

public class GetByIdCommentQueryRequest:IRequest<GetByIdCommentQueryResponse>
{
    public int Id { get; set; }
   
}