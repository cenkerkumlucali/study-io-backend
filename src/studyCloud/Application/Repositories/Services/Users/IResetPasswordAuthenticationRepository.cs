using Domain.Entities.Users;

namespace Application.Repositories.Services.Users;

public interface IResetPasswordAuthenticationRepository : IAsyncRepository<ResetPasswordAuthentication>, IRepository<ResetPasswordAuthentication>
{
}