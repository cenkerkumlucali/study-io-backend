using Application.Abstractions.Services;
using AutoMapper;
using MediatR;

namespace Application.Features.Comment.Commands.CreateComment;

public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommandRequest,CreateCommentCommandResponse>
{
    private readonly ICommentService _commentService;
    private IMapper _mapper;

    public CreateCommentCommandHandler(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.Comment mappedComment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
        Domain.Entities.Comments.Comment createdComment = await _commentService.Upload(mappedComment);
        CreateCommentCommandResponse mappedCreateCommentResponse = _mapper.Map<CreateCommentCommandResponse>(createdComment);
        return mappedCreateCommentResponse;
    }
}