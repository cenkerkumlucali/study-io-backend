using Application.Exceptions;
using Application.Repositories.Services.Users;
using Application.Security.Hashing;

namespace Application.Features.Users.User.Rules;

public class UserBusinessRules
{
    private readonly IUserRepository _userRepository;

    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task UserIdShouldExistWhenSelected(int id)
    {
        Domain.Entities.Users.User? result = await _userRepository.GetAsync(b => b.Id == id);
        if (result == null) throw new BusinessException("User not exists.");
    }

    public Task UserShouldBeExist(Domain.Entities.Users.User? user)
    {
        if (user is null) throw new BusinessException("User not exists.");
        return Task.CompletedTask;
    }

    public Task UserPasswordShouldBeMatch(Domain.Entities.Users.User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            throw new BusinessException("Password don't match.");
        return Task.CompletedTask;
    }
}