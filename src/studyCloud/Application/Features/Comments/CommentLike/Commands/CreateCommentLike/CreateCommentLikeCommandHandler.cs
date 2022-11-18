using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;

namespace Application.Features.Comments.CommentLike.Commands.CreateCommentLike;

public class CreateCommentLikeCommandHandler:IRequestHandler<CreateCommentLikeCommandRequest,CreateCommentLikeCommandResponse>
{
    private readonly ICommentLikeRepository _commentLikeRepository;
    private readonly IMapper _mapper;


    public CreateCommentLikeCommandHandler(ICommentLikeRepository commentLikeRepository, IMapper mapper)
    {
        _commentLikeRepository = commentLikeRepository;
        _mapper = mapper;
    }

    public async Task<CreateCommentLikeCommandResponse> Handle(CreateCommentLikeCommandRequest request, CancellationToken cancellationToken)
    {
        Domain.Entities.Comments.CommentLike mappedCommentLike = _mapper.Map<Domain.Entities.Comments.CommentLike>(request);
        Domain.Entities.Comments.CommentLike createdCommentLike = await _commentLikeRepository.AddAsync(mappedCommentLike);
        CreateCommentLikeCommandResponse mappedCreateCommentLikeDto = _mapper.Map<CreateCommentLikeCommandResponse>(createdCommentLike);
        return mappedCreateCommentLikeDto;
    }
}