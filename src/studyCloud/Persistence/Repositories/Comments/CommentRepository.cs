using Application.Repositories.Services.Comments;
using Domain.Entities.Comments;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentRepository:EfRepositoryBase<Comment,BaseDbContext>,ICommentRepository
{
    public CommentRepository(BaseDbContext context) : base(context)
    {
    }
}