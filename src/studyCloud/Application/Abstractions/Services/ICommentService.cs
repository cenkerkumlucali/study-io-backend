using Domain.Entities.Comments;
using Domain.Entities.Feeds;

namespace Application.Abstractions.Services;

public interface ICommentService
{
    Task<Comment?> GetById(int id);
    Task<Comment> Upload(Comment comment);
    Task DeleteAllInPost(Post post);
}