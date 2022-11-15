using Domain.Entities.Users;

namespace Application.Services.Repositories.Users;

public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
{
    
}