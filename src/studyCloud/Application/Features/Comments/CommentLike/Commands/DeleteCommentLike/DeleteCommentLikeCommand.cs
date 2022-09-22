using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.DeleteCommentLike;

public class DeleteCommentLikeCommand:IRequest<DeletedCommentLikeDto>
{
    public int Id { get; set; }
    public class DeleteCommentLikeCommandHandler:IRequestHandler<DeleteCommentLikeCommand,DeletedCommentLikeDto>
    {
        private ICommentLikeRepository _commentLikeRepository;
        private IMapper _mapper;

        public DeleteCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCommentLikeDto> Handle(DeleteCommentLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentLike commentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
            Domain.Entities.Comments.CommentLike deletedCommentLike =
                await _commentLikeRepository.DeleteAsync(commentLike);
            DeletedCommentLikeDto deletedCommentLikeDto =
                _mapper.Map<DeletedCommentLikeDto>(deletedCommentLike);
            return deletedCommentLikeDto;
        }
    }
}