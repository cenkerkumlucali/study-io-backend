namespace Application.Repositories.Services.RefreshToken;

public interface IRefreshTokenRepository:IRedisRepository<Domain.Entities.Users.RefreshToken>
{
    IEnumerable<string> GetUsers();
    Task<Domain.Entities.Users.RefreshToken> GetByRefreshToken(string refreshToken);
}