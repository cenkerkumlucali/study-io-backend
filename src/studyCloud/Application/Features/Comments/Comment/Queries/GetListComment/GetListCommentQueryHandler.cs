using Application.Abstractions.Services.Paging;
using Application.Features.Comments.Comment.Models;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.Comment.Queries.GetListComment;

public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQueryRequest, CommentListModel>
{
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CommentListModel> Handle(GetListCommentQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Comments.Comment> comment =
            await _commentRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include:c=>c.Include(c=>c.User)
                    .Include(c=>c.Parent)
                    .Include(c=>c.Parent.User));
        CommentListModel mappedCommentListModel =
            _mapper.Map<CommentListModel>(comment);
        return mappedCommentListModel;
    }
}