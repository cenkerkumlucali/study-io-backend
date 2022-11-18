using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IUserCoinRepository:IAsyncRepository<UserCoin>,IRepository<UserCoin>
{
    
}