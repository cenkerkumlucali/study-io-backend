using Domain.Entities.Users;

namespace Application.Services.Repositories.Users;

public interface IUserImageRepository:IAsyncRepository<UserImageFile>,IRepository<UserImageFile>
{
    
}