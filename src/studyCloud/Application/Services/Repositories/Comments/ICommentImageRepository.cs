using Core.Persistence.Repositories;
using Domain.Entities.Comments;

namespace Application.Services.Repositories.Comments;

public interface ICommentImageRepository:IAsyncRepository<CommentImage>,IRepository<CommentImage>
{
    
}