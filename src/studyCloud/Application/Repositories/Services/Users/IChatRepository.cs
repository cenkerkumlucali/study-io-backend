using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IChatRepository:IAsyncRepository<Chat>,IRepository<Chat>
{
    
}