using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentImage.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentImage.Queries.GetByIdCommentImage;

public class GetByIdCommentImageQuery:IRequest<GetByIdCommentImageDto>
{
    public int Id { get; set; }
    public class GetByIdCommentImageQueryHandler:IRequestHandler<GetByIdCommentImageQuery,GetByIdCommentImageDto>
    {
        private ICommentImageRepository _commentImageRepository;
        private IMapper _mapper;

        public GetByIdCommentImageQueryHandler(ICommentImageRepository commentImageRepository, IMapper mapper)
        {
            _commentImageRepository = commentImageRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCommentImageDto> Handle(GetByIdCommentImageQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentImage? commentImage =
                await _commentImageRepository.GetAsync(c => c.Id == request.Id);
            GetByIdCommentImageDto getByIdCommentImageDto =
                _mapper.Map<GetByIdCommentImageDto>(commentImage);
            return getByIdCommentImageDto;
        }
    }
}