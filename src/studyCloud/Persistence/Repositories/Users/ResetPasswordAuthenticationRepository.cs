using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class ResetPasswordAuthenticationRepository : EfRepositoryBase<ResetPasswordAuthentication, BaseDbContext>,
    IResetPasswordAuthenticationRepository
{
    public ResetPasswordAuthenticationRepository(BaseDbContext context) : base(context)
    {
    }
}