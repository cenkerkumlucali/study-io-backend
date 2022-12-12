using Application.Abstractions.Services.Paging;
using Application.Features.Comment.Models;
using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Queries.GetListComment;

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
                size: request.PageRequest.PageSize);
        CommentListModel mappedCommentListModel =
            _mapper.Map<CommentListModel>(comment);
        return mappedCommentListModel;
    }
}