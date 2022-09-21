using Core.Persistence.Repositories;
using Domain.Entities.Users;

namespace Application.Services.Repositories.Users;

public interface IUserCoinRepository:IAsyncRepository<UserCoin>,IRepository<UserCoin>
{
    
}