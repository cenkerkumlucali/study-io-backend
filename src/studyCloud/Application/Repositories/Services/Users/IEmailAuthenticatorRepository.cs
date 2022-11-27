using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IEmailAuthenticatorRepository : IAsyncRepository<EmailAuthenticator>, IRepository<EmailAuthenticator>
{
}