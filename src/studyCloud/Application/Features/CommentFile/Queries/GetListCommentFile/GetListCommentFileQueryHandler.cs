using Application.Abstractions.Services.Paging;
using Application.Repositories.Services.Comments;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.CommentFile.Queries.GetListCommentFile;

public class GetListCommentFileQueryHandler : IRequestHandler<GetListCommentFileQueryRequest, ListCommentFileQueryResponse>
{
    private ICommentImageFileRepository _commentImageRepository;
    private IMapper _mapper;

    public GetListCommentFileQueryHandler(ICommentImageFileRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<ListCommentFileQueryResponse> Handle(GetListCommentFileQueryRequest request,
        CancellationToken cancellationToken)
    {
        IPaginate<CommentImageFile> commentImage =
            await _commentImageRepository.GetListAsync(c=>c.Id == request.Id,
                include: c => c.Include(c=>c.Comments));
        ListCommentFileQueryResponse mappedCommentImageListModel =
            _mapper.Map<ListCommentFileQueryResponse>(commentImage);
        return mappedCommentImageListModel;
    }
}