using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.CreateCommentLike;

public class CreateCommentLikeCommand:IRequest<CreatedCommentLikeDto>
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
    
    public class CreateCommentLikeCommandHandler:IRequestHandler<CreateCommentLikeCommand,CreatedCommentLikeDto>
    {
        private readonly ICommentLikeRepository _commentLikeRepository;
        private readonly IMapper _mapper;


        public CreateCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<CreatedCommentLikeDto> Handle(CreateCommentLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentLike mappedCommentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
            Domain.Entities.Comments.CommentLike createdCommentLike = await _commentLikeRepository.AddAsync(mappedCommentLike);
            CreatedCommentLikeDto mappedCreateCommentLikeDto = _mapper.Map<CreatedCommentLikeDto>(createdCommentLike);
            return mappedCreateCommentLikeDto;
        }
    }
}