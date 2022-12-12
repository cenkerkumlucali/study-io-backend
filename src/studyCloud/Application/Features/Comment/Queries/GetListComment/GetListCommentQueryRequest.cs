using Application.Features.Comment.Models;
using Application.RequestParameters;
using MediatR;

namespace Application.Features.Comment.Queries.GetListComment;

public class GetListCommentQueryRequest : IRequest<CommentListModel>
{
    public PageRequest PageRequest { get; set; }

    
}