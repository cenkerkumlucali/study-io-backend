using Domain.Entities.Comments;

namespace Application.Services.Repositories.Comments;

public interface ICommentRepository:IAsyncRepository<Comment>,IRepository<Comment>
{
    
}