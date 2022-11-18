using Domain.Entities.Comments;

namespace Application.Repositories.Services.Comments;

public interface ICommentRepository:IAsyncRepository<Comment>,IRepository<Comment>
{
    
}