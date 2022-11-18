namespace Application.Repositories.Services.RefreshToken;

public interface IRefreshTokenRepository : IAsyncRepository<Domain.Entities.Users.RefreshToken>, IRepository<Domain.Entities.Users.RefreshToken>
{
}