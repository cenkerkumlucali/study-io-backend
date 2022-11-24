using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User> GetById(int id);
    Task<User> Update(User user);
    Task<User> GetByUserName(string userName);
    Task<bool> ResetPassword(string email);
}