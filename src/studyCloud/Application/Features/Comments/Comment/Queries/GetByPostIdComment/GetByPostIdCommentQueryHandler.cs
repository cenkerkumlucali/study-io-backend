using Application.Repositories.Services.Comments;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Comments.Comment.Queries.GetByPostIdComment;

public class GetByPostIdCommentQueryHandler : IRequestHandler<GetByPostIdCommentQueryRequest,
    List<GetByPostIdCommentQueryResponse>>
{
    private readonly ICommentRepository _commentRepository;
    private IMapper _mapper;

    public GetByPostIdCommentQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<GetByPostIdCommentQueryResponse>> Handle(GetByPostIdCommentQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<Domain.Entities.Comments.Comment> comments = await _commentRepository.GetAllAsync(
            c => c.PostId == request.PostId,
            include: c => c.Include(u => u.User)
                .ThenInclude(c => c.UserImageFiles)
                .Include(c => c.CommentLikes)
                .Include(c => c.CommentImageFiles));
        comments = comments.Where(c => c.ParentId == null).ToList();
        List<GetByPostIdCommentQueryResponse>? response = _mapper.Map<List<GetByPostIdCommentQueryResponse>>(comments);
        return response;
    }
}