using Application.Features.Comments.Comment.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Queries.GetByIdComment;

public class GetByIdCommentQuery:IRequest<GetByIdCommentDto>
{
    public int Id { get; set; }
    public class GetByIdCommentQueryHandler:IRequestHandler<GetByIdCommentQuery,GetByIdCommentDto>
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public GetByIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCommentDto> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.Comment? comment =
                await _commentRepository.GetAsync(c => c.Id == request.Id);
            GetByIdCommentDto getByIdCommentDto =
                _mapper.Map<GetByIdCommentDto>(comment);
            return getByIdCommentDto;
        }
    }
}