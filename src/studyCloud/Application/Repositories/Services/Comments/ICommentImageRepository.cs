using Domain.Entities.Comments;

namespace Application.Repositories.Services.Comments;

public interface ICommentImageRepository:IAsyncRepository<CommentImageFile>,IRepository<CommentImageFile>
{
    
}