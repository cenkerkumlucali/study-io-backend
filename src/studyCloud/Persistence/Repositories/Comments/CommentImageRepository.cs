using Application.Services.Repositories.Comments;
using Core.Persistence.Repositories;
using Domain.Entities.Comments;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentImageRepository:EfRepositoryBase<CommentImage,BaseDbContext>,ICommentImageRepository
{
    public CommentImageRepository(BaseDbContext context) : base(context)
    {
    }
}