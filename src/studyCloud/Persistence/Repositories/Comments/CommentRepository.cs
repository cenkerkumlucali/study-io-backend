using Application.Services.Repositories.Comments;
using Core.Persistence.Repositories;
using Domain.Entities.Comments;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentRepository:EfRepositoryBase<Comment,BaseDbContext>,ICommentRepository
{
    public CommentRepository(BaseDbContext context) : base(context)
    {
    }
}