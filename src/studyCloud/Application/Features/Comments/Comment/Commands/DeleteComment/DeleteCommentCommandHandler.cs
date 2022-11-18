using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Commands.DeleteComment;

public class DeleteCommentCommandHandler:IRequestHandler<DeleteCommentCommandRequest,DeleteCommentCommandResponse>
{
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.Comment comment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
        Domain.Entities.Comments.Comment deletedComment =
            await _commentRepository.DeleteAsync(comment);
        DeleteCommentCommandResponse deletedCommentDto =
            _mapper.Map<DeleteCommentCommandResponse>(deletedComment);
        return deletedCommentDto;
    }
}