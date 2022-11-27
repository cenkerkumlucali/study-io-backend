using Application.Repositories.Services.Users;
using Domain.Entities.Users;
using Persistence.Contexts;

namespace Persistence.Repositories.Users;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, BaseDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(BaseDbContext context) : base(context)
    {
    }
}