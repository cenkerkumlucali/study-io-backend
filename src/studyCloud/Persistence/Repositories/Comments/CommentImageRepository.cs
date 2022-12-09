using Application.Repositories.Services.Comments;
using Domain.Entities.Comments;
using Domain.Entities.ImageFile;
using Persistence.Contexts;

namespace Persistence.Repositories.Comments;

public class CommentImageRepository:EfRepositoryBase<CommentImageFile,BaseDbContext>,ICommentImageFileRepository
{
    public CommentImageRepository(BaseDbContext context) : base(context)
    {
    }
}