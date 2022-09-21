using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities.Comments;

public class CommentLike : Entity
{
    public int UserId { get; set; }
    public int CommentId { get; set; }
    public virtual User User { get; set; }
    public virtual Comment Comment { get; set; }

    public CommentLike()
    {
    }

    public CommentLike(int userId, int commentId, int id) : this()
    {
        Id = id;
        UserId = userId;
        CommentId = commentId;
    }
}