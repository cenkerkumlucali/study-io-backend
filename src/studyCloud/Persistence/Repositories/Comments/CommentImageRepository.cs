using Application.Services.Repositories.Comments;
using Domain.Entities.Comments;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentImageRepository:EfRepositoryBase<CommentImageFile,BaseDbContext>,ICommentImageRepository
{
    public CommentImageRepository(BaseDbContext context) : base(context)
    {
    }
}