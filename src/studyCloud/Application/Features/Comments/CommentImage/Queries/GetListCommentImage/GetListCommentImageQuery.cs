using Application.Features.Comments.Comment.Models;
using Application.Features.Comments.CommentImage.Models;
using Application.Services.Repositories.Comments;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.CommentImage.Queries.GetListCommentImage;

public class GetListCommentImageQuery : IRequest<CommentImageListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListCommentImageQueryHandler : IRequestHandler<GetListCommentImageQuery, CommentImageListModel>
    {
        private ICommentImageRepository _commentImageRepository;
        private IMapper _mapper;

        public GetListCommentImageQueryHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
        {
            _commentImageRepository = commentImageRepository;
            _mapper = mapper;
        }

        public async Task<CommentImageListModel> Handle(GetListCommentImageQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<Domain.Entities.Comments.CommentImage> commentImage =
                await _commentImageRepository.GetListAsync(index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: c => c.Include(c => c.Comment)
                        .Include(c => c.Comment.User));
            CommentImageListModel mappedCommentImageListModel =
                _mapper.Map<CommentImageListModel>(commentImage);
            return mappedCommentImageListModel;
        }
    }
}