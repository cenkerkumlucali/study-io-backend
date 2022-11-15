using Application.Services.Repositories.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.Comment.Commands.CreateComment;

public class CreateCommentCommandHandler:IRequestHandler<CreateCommentCommandRequest,CreateCommentCommandResponse>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;


    public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.Comment mappedComment = _mapper.Map<Domain.Entities.Comments.Comment>(request);
        Domain.Entities.Comments.Comment createdComment = await _commentRepository.AddAsync(mappedComment);
        CreateCommentCommandResponse mappedCreateCommentResponse = _mapper.Map<CreateCommentCommandResponse>(createdComment);
        return mappedCreateCommentResponse;
    }
}