using Domain.Entities.Comments;

namespace Application.Repositories.Services.Comments;

public interface ICommentLikeRepository:IAsyncRepository<CommentLike>,IRepository<CommentLike>
{
    
}