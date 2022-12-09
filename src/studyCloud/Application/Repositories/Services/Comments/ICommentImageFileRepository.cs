using Domain.Entities.Comments;
using Domain.Entities.ImageFile;

namespace Application.Repositories.Services.Comments;

public interface ICommentImageFileRepository:IAsyncRepository<CommentImageFile>,IRepository<CommentImageFile>
{
    
}