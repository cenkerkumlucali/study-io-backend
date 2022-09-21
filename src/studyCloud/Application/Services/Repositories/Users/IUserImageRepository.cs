using Core.Persistence.Repositories;
using Domain.Entities.Users;

namespace Application.Services.Repositories.Users;

public interface IUserImageRepository:IAsyncRepository<UserImage>,IRepository<UserImage>
{
    
}