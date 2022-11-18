using Application.Repositories.Services.RefreshToken;
using Persistence.Contexts;

namespace Persistence.Repositories.RefreshToken;

public class RefreshTokenRepository: EfRepositoryBase<Domain.Entities.Users.RefreshToken, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context)
    {
    }
}