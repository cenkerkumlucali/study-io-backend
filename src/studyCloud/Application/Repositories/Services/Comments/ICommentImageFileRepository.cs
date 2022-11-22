using Domain.Entities.Comments;

namespace Application.Repositories.Services.Comments;

public interface ICommentImageFileRepository:IAsyncRepository<CommentImageFile>,IRepository<CommentImageFile>
{
    
}