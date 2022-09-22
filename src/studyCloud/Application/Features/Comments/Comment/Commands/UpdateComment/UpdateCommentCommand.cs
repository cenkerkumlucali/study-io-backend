using Application.Features.Comments.Comment.Dtos;
using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Commands.UpdateComment;

public class UpdateCommentCommand : IRequest<UpdatedCommentDto>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? ParentId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }

    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, UpdatedCommentDto>
    {
        private ICommentRepository _commentRepository;
        private IMapper _mapper;

        public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedCommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Comments.Comment comment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
            Domain.Entities.Comments.Comment createdComment =
                await _commentRepository.UpdateAsync(comment);
            UpdatedCommentDto updatedCommentDto =
                _mapper.Map<UpdatedCommentDto>(createdComment);
            return updatedCommentDto;
        }
    }
}