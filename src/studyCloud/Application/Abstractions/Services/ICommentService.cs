using Domain.Entities.Comments;

namespace Application.Abstractions.Services;

public interface ICommentService
{
    Task<Comment?> GetById(int id);
}