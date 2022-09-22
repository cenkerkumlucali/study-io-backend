using Application.Features.Comments.Comment.Dtos;
using Application.Features.Comments.CommentLike.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.UpdateCommentLike;

public class UpdateCommentLikeCommand : IRequest<UpdatedCommentLikeDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CommentId { get; set; }

    public class UpdateCommentLikeCommandHandler : IRequestHandler<UpdateCommentLikeCommand, UpdatedCommentLikeDto>
    {
        private ICommentLikeRepository _commentLikeRepository;
        private IMapper _mapper;

        public UpdateCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
        {
            _commentLikeRepository = commentLikeRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCommentLikeDto> Handle(UpdateCommentLikeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.CommentLike commentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
            Domain.Entities.Comments.CommentLike createdCommentLike =
                await _commentLikeRepository.UpdateAsync(commentLike);
            UpdatedCommentLikeDto updatedCommentLikeDto =
                _mapper.Map<UpdatedCommentLikeDto>(createdCommentLike);
            return updatedCommentLikeDto;
        }
    }
}