using MediatR;

namespace Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryRequest:IRequest<GetByIdCommentFileQueryResponse>
{
    public int Id { get; set; }
    
}