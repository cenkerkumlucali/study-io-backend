using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IBlockRepository:IAsyncRepository<Block>,IRepository<Block>
{
    
}