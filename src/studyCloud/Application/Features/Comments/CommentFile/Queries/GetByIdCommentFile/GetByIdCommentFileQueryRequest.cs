using MediatR;

namespace Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryRequest:IRequest<GetByIdCommentFileQueryResponse>
{
    public long Id { get; set; }
    
}