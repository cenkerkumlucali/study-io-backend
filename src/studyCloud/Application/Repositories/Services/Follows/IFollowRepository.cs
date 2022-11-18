using Domain.Entities;

namespace Application.Repositories.Services.Follows;

public interface IFollowRepository:IAsyncRepository<Follow>,IRepository<Follow>
{
    
}