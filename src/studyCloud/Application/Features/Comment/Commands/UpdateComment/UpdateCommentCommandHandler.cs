using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Commands.UpdateComment;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
{
    private ICommentRepository _commentRepository;
    private IMapper _mapper;

    public UpdateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.Comment comment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
        Domain.Entities.Comments.Comment createdComment =
            await _commentRepository.UpdateAsync(comment);
        UpdateCommentCommandResponse updatedCommentDto =
            _mapper.Map<UpdateCommentCommandResponse>(createdComment);
        return updatedCommentDto;
    }
}