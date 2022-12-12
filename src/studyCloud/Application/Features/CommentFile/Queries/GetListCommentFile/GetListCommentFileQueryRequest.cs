using MediatR;

namespace Application.Features.CommentFile.Queries.GetListCommentFile;

public class GetListCommentFileQueryRequest : IRequest<ListCommentFileQueryResponse>
{
   public long Id { get; set; }
}