using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentFile.Queries.GetByIdCommentFile;

public class GetByIdCommentFileQueryHandler:IRequestHandler<GetByIdCommentFileQueryRequest,GetByIdCommentFileQueryResponse>
{
    private ICommentImageRepository _commentImageRepository;
    private IMapper _mapper;

    public GetByIdCommentFileQueryHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
    {
        _commentImageRepository = commentImageRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdCommentFileQueryResponse> Handle(GetByIdCommentFileQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentImageFile? commentImage =
            await _commentImageRepository.GetAsync(c => c.Id == request.Id);
        GetByIdCommentFileQueryResponse getByIdCommentImageDto =
            _mapper.Map<GetByIdCommentFileQueryResponse>(commentImage);
        return getByIdCommentImageDto;
    }
}