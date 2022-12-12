using MediatR;

namespace Application.Features.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryRequest:IRequest<GetByIdCommentFileQueryResponse>
{
    public long Id { get; set; }
    
}