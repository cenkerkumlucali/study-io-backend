using Application.Features.Users.User.Dtos;
using Domain.Entities.Users;

namespace Application.Abstractions.Services;

public interface IUserService
{
    Task<User> AddAsync(User user);
    Task<User?> GetByEmail(string email);
    Task<User> GetById(int id);
    Task<IList<User>> GetAllByUsernameIn(ICollection<string> userNames);
    Task<IList<User>> GetAllByIdIn(ICollection<int> ids);
    Task<User> Update(User user);
    Task<User> GetByUserName(string userName);
    Task<bool> ResetPassword(string email);
    Task<ProfileDto> GetUserProfile(int username, int memberId);
    Task<ProfileDto> GetUserProfileByLoginMemberIdAndTargetId(int loginUserId, int targetId);
}