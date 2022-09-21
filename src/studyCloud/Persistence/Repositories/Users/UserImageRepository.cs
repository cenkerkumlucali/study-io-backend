using Application.Services.Repositories.Users;
using Core.Persistence.Repositories;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class UserImageRepository:EfRepositoryBase<UserImage,BaseDbContext>,IUserImageRepository
{
    public UserImageRepository(BaseDbContext context) : base(context)
    {
    }
}