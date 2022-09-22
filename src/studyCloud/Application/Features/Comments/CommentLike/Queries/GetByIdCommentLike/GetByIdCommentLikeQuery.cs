using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Queries.GetByIdCommentLike;

public class GetByIdCommentLikeQuery:IRequest<GetByIdCommentLikeDto>
{
    public int Id { get; set; }
    public class GetByIdCommentLikeQueryHandler:IRequestHandler<GetByIdCommentLikeQuery,GetByIdCommentLikeDto>
    {
        private ICommentLikeRepository _commentLikeRepository;
        private IMapper _mapper;

        public GetByIdCommentLikeQueryHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCommentLikeDto> Handle(GetByIdCommentLikeQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentLike? commentLike =
                await _commentLikeRepository.GetAsync(c => c.Id == request.Id);
            GetByIdCommentLikeDto getByIdCommentLikeDto =
                _mapper.Map<GetByIdCommentLikeDto>(commentLike);
            return getByIdCommentLikeDto;
        }
    }
}