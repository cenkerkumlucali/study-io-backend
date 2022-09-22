using Application.Features.Comments.Comment.Models;
using Application.Services.Repositories.Comments;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetListComment;

public class GetListCommentQuery : IRequest<CommentListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCommentQueryHandler : IRequestHandler<GetListCommentQuery, CommentListModel>
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public GetListCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<CommentListModel> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Comments.Comment> comment =
                await _commentRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
            CommentListModel mappedCommentListModel =
                _mapper.Map<CommentListModel>(comment);
            return mappedCommentListModel;
        }
    }
}