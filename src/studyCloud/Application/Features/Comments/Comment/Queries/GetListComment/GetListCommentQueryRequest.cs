using Application.Features.Comments.Comment.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetListComment;

public class GetListCommentQueryRequest : IRequest<CommentListModel>
{
    public PageRequest PageRequest { get; set; }

    
}