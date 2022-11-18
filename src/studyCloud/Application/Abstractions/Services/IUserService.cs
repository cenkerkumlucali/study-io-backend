using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    public Task<User?> GetByEmail(string email);
    public Task<User> GetById(int id);
    public Task<User> Update(User user);
}