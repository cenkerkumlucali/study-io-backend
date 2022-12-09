using Application.Features.Users.User.Dtos;
using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User> GetById(long id);
    Task<IList<User>> GetAllByUsernameIn(ICollection<string> userNames);
    Task<IList<User>> GetAllByIdIn(ICollection<long> ids);
    Task<User> Update(User user);
    Task<User> GetByUserName(string userName);
    Task<ProfileDto> GetUserProfile(long username, long memberId);
    Task<ProfileDto> GetUserProfileByLoginMemberIdAndTargetId(long loginUserId, long targetId);
    Task<bool> ResetPassword(User user, string password, string confirmPassword);
}