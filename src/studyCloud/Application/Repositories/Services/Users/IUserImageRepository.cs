using Domain.Entities.ImageFile;
using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IUserImageRepository:IAsyncRepository<UserImageFile>,IRepository<UserImageFile>
{
    
}