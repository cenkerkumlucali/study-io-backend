using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetByIdCommentLike;

public class GetByIdCommentLikeQueryRequest:IRequest<GetByIdCommentLikeQueryResponse>
{
    public int Id { get; set; }
    public class GetByIdCommentLikeQueryHandler:IRequestHandler<GetByIdCommentLikeQueryRequest,GetByIdCommentLikeQueryResponse>
    {
        private ICommentLikeRepository _commentLikeRepository;
        private IMapper _mapper;

        public GetByIdCommentLikeQueryHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCommentLikeQueryResponse> Handle(GetByIdCommentLikeQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentLike? commentLike =
                await _commentLikeRepository.GetAsync(c => c.Id == request.Id);
            GetByIdCommentLikeQueryResponse getByIdCommentLikeDto =
                _mapper.Map<GetByIdCommentLikeQueryResponse>(commentLike);
            return getByIdCommentLikeDto;
        }
    }
}