using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetByIdComment;

public class GetByIdCommentQueryHandler:IRequestHandler<GetByIdCommentQueryRequest,GetByIdCommentQueryResponse>
{
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<GetByIdCommentQueryResponse> Handle(GetByIdCommentQueryRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.Comment? comment =
            await _commentRepository.GetAsync(c => c.Id == request.Id);
        GetByIdCommentQueryResponse getByIdCommentDto =
            _mapper.Map<GetByIdCommentQueryResponse>(comment);
        return getByIdCommentDto;
    }
}