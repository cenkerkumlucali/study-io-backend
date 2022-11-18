using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IUserRepository:IAsyncRepository<User>,IRepository<User>
{
    
}