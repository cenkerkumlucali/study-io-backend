using MediatR;

namespace Application.Features.Comments.CommentFile.Queries.GetListCommentFile;

public class GetListCommentFileQueryRequest : IRequest<ListCommentFileQueryResponse>
{
   public int Id { get; set; }
}