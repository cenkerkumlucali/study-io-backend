using Application.Abstractions.Services.Paging;
using Application.Features.Comments.CommentFile.Models;
using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.CommentFile.Queries.GetListCommentFile;

public class GetListCommentFileQueryHandler : IRequestHandler<GetListCommentFileQueryRequest, CommentImageListModel>
{
    private ICommentImageRepository _commentImageRepository;
    private IMapper _mapper;

    public GetListCommentFileQueryHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<CommentImageListModel> Handle(GetListCommentFileQueryRequest request,
        CancellationToken cancellationToken)
    {
        IPaginate<Domain.Entities.Comments.CommentImageFile> commentImage =
            await _commentImageRepository.GetListAsync(index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                include: c => c.Include(c=>c.Comments));
        CommentImageListModel mappedCommentImageListModel =
            _mapper.Map<CommentImageListModel>(commentImage);
        return mappedCommentImageListModel;
    }
}