using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IOtpAuthenticatorRepository : IAsyncRepository<OtpAuthenticator>, IRepository<OtpAuthenticator>
{
}