using Application.Services.Repositories.Users;
using Core.Persistence.Repositories;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class UserCoinRepository:EfRepositoryBase<UserCoin,BaseDbContext>,IUserCoinRepository
{
    public UserCoinRepository(BaseDbContext context) : base(context)
    {
    }
}