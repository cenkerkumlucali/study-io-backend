using Application.Abstractions.Services;
using Application.Repositories.Services.Comments;
using Domain.Entities.Comments;

namespace Persistence.Services;

public class CommentManager:ICommentService
{
    private ICommentRepository _commentRepository;

    public CommentManager(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<Comment?> GetById(int id)
    {
        return await _commentRepository.GetAsync(c => c.Id == id);
    }
}