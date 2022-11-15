using Application.Services.Repositories.Users;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class UserImageRepository:EfRepositoryBase<UserImageFile,BaseDbContext>,IUserImageRepository
{
    public UserImageRepository(BaseDbContext context) : base(context)
    {
    }
}