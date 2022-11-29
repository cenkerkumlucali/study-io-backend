using Application.Abstractions.Services;
using Application.Repositories.Services.Users;
using Domain.Entities.Users;

namespace Persistence.Services;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> AddAsync(User user)
    {
        User createdUser = await _userRepository.AddAsync(user);
        return createdUser;
    }

    public async Task<User?> GetByEmail(string email)
    {
        User? user = await _userRepository.GetAsync(u => u.Email == email);
        return user;
    }

    public async Task<User> GetById(int id)
    {
        User? user = await _userRepository.GetAsync(u => u.Id == id);
        return user;
    }

    public async Task<IList<User>> GetAllByUsernameIn(ICollection<string> userNames)
    {
        IList<User> users = (await _userRepository.GetListAsync(c => userNames.Contains(c.UserName))).Items;
        return users;
    }

    public async Task<User> Update(User user)
    {
        User updatedUser = await _userRepository.UpdateAsync(user);
        return updatedUser;
    }

    public async Task<User> GetByUserName(string userName)
    {
        User user = await _userRepository.GetAsync(c => c.UserName == userName);
        return user;
    }

    public async Task<bool> ResetPassword(string email)
    {
        var user = GetByEmail(email);
        if (user == null)
        {
            
        }

        return true;
    }
}