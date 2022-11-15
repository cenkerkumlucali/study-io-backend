using Domain.Entities.Follow;

namespace Application.Services.Repositories.Follows;

public interface IFollowRepository:IAsyncRepository<Follow>,IRepository<Follow>
{
    
}