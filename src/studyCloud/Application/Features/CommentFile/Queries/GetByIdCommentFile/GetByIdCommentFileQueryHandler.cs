using Application.Repositories.Services.Comments;
using AutoMapper;
using Domain.Entities.ImageFile;
using MediatR;

namespace Application.Features.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryHandler:IRequestHandler<GetByIdCommentFileQueryRequest,GetByIdCommentFileQueryResponse>
{
    private ICommentImageFileRepository _commentImageRepository;
    private IMapper _mapper;

    public GetByIdCommentFileQueryHandler(ICommentImageFileRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdCommentFileQueryResponse> Handle(GetByIdCommentFileQueryRequest request, CancellationToken cancellationToken)
    {
        CommentImageFile? commentImage =
            await _commentImageRepository.GetAsync(c => c.Id == request.Id);
        GetByIdCommentFileQueryResponse getByIdCommentImageDto =
            _mapper.Map<GetByIdCommentFileQueryResponse>(commentImage);
        return getByIdCommentImageDto;
    }
}