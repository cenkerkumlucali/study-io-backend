using Application.Features.Comments.Comment.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Commands.DeleteComment;

public class DeleteCommentCommand:IRequest<DeletedCommentDto>
{
    public int Id { get; set; }
    public class DeleteCommentCommandHandler:IRequestHandler<DeleteCommentCommand,DeletedCommentDto>
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<DeletedCommentDto> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.Comment comment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
            Domain.Entities.Comments.Comment deletedComment =
                await _commentRepository.DeleteAsync(comment);
            DeletedCommentDto deletedCommentDto =
                _mapper.Map<DeletedCommentDto>(deletedComment);
            return deletedCommentDto;
        }
    }
}