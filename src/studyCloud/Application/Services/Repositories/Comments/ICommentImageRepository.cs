using Domain.Entities.Comments;

namespace Application.Services.Repositories.Comments;

public interface ICommentImageRepository:IAsyncRepository<CommentImageFile>,IRepository<CommentImageFile>
{
    
}