using Core.Persistence.Repositories;
using Domain.Entities.Comments;

namespace Application.Services.Repositories.Comments;

public interface ICommentLikeRepository:IAsyncRepository<CommentLike>,IRepository<CommentLike>
{
    
}