using Application.Services.Repositories.Comments;
using Domain.Entities.Comments;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentLikeRepository:EfRepositoryBase<CommentLike,BaseDbContext>,ICommentLikeRepository
{
    public CommentLikeRepository(BaseDbContext context) : base(context)
    {
    }
}